using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;       
using SatoshiMinesStrategyStealer.Core.Models;
using SatoshiMinesStrategyStealer.Core.Models.Enums;
using SatoshiMinesStrategyStealer.UI.Models;
using SatoshiMinesStrategyStealer.UI.Models.Enums; 
using Timer = System.Timers.Timer;

namespace SatoshiMinesStrategyStealer.UI.Controls
{
    public sealed class SatoshiMinesGrid : Control
    {
        public event EventHandler OnCashoutClicked;

        private bool _gameStarted; 
        public bool GameStarted
        {
            get { return _gameStarted; }
            set
            {
                _gameStarted = value;
                Invalidate();
            }
        }

        private readonly Timer _resetBoardTimer;
        private readonly GuessTile[] _tiles;
        private Rectangle _cashOutRectangle;

        public SatoshiMinesGrid()
        {
            _resetBoardTimer = new Timer { Interval = 5000 };
            _resetBoardTimer.Elapsed += delegate
            {
                ResetTiles();
                GameStarted = false;

                _resetBoardTimer.Stop();
            };

            _tiles = Enum.GetValues(typeof(Guess))
                .Cast<Guess>()
                .Where(tile => tile != Guess.None)
                .Select(g => new GuessTile(g)).ToArray();

            DoubleBuffered = true;
        }

        public async Task UpdateMine(Guess guess, GuessResponse response)
        {
            var tile = _tiles.FirstOrDefault(t => t.Guess == guess);
            var isBomb = response.Outcome.Equals("bomb");

            if (tile != null)
            {
                tile.Type = TileType.Money;
                Invalidate();
            }

            if (!isBomb)
                return;

            _resetBoardTimer.Start();       
            await ShowHiddenMines(response.Bombs).ConfigureAwait(false);
        }

        private void InvalidateTiles()
        {
            var length = Height / 5;

            var mainIndex = 0;
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    _tiles[mainIndex].Rectangle = new Rectangle(j * length, i * length, length - 2, length - 2);
                    mainIndex++;
                }
            }

            Invalidate();
        }        

        public async Task ShowHiddenMines(string mines)
        {
            foreach (var tile in _tiles)
            {
                if (mines.Split('-').Contains(((int) tile.Guess).ToString()))
                    tile.Type = TileType.Mine;    
            }

            Invalidate();                    
            await Task.Delay(5000);
        }

        public void ShowPlayedGame(PlayedGameResponse gameResponse)
        {
            foreach (var tile in _tiles)
            {
                if (gameResponse.Bombs.Contains(tile.Guess))   
                    tile.Type = TileType.Mine;            
                else if (gameResponse.Guesses.Contains(tile.Guess))  
                    tile.Type = TileType.Money;                     
                else                                       
                    tile.Type = TileType.Unclicked;    
            }

            Invalidate();         
        }

        private void ResetTiles()
        {
            foreach (var tile in _tiles)
                tile.Type = TileType.Unclicked;
        }

        private static Brush BrushFromTile(GuessTile tile)
        {
            Color tileColor;
            switch (tile.Type)
            {
                case TileType.Mine:
                    tileColor = Color.FromArgb(253, 86, 93);
                    break;
                case TileType.Money:
                    tileColor = Color.FromArgb(129, 218, 102);
                    break;
                default:
                    tileColor = Color.DeepSkyBlue;
                    break;
            }
            return new SolidBrush(tileColor);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            InvalidateTiles();
            base.OnHandleCreated(e);
        }

        protected override void OnResize(EventArgs e)
        {
            InvalidateTiles();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            using (var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                foreach (var tile in _tiles)
                {
                    using (var tileFillBrush = BrushFromTile(tile))
                        g.FillRectangle(tileFillBrush, tile.Rectangle);

                    g.DrawString(((byte) tile.Guess).ToString(), Font, Brushes.White, tile.Rectangle, format);
                }

                if (_gameStarted)
                {
                    using (var font = new Font("Arial", 12f, FontStyle.Bold))
                    {
                        _cashOutRectangle = new Rectangle((Width - 140)/2, Height - 20, 140, 20);

                        g.FillRectangle(Brushes.Gold, _cashOutRectangle);
                        g.DrawString("CASHOUT", font, Brushes.White, _cashOutRectangle, format);
                    }
                }
            }

            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_gameStarted && _cashOutRectangle.Contains(e.Location))
            {
                ResetTiles();

                GameStarted = false;
                OnCashoutClicked?.Invoke(this, null);
            }

            base.OnMouseClick(e);
        }   
    }
}