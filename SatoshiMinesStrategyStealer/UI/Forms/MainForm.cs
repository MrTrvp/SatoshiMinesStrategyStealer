using System;              
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatoshiMinesStrategyStealer.Core.Models;
using SatoshiMinesStrategyStealer.Core.Models.Enums;
using SatoshiMinesStrategyStealer.Core.Providers;
using SatoshiMinesStrategyStealer.Core.Providers.Strategies;
using SatoshiMinesStrategyStealer.UI.Controls;
using SatoshiMinesStrategyStealer.UI.Helpers;
using SatoshiMinesStrategyStealer.UI.Models.Enums;

namespace SatoshiMinesStrategyStealer.UI.Forms
{
    public partial class MainForm : Form
    {                                
        private readonly LiveGameTracker _tracker; 
        private readonly SatoshiMinesProvider _provider;

        private Player _currentPlayer;
        private Game _currentGame;

        public MainForm()
        {
            _tracker = new LiveGameTracker();
            _provider = new SatoshiMinesProvider();

            InitializeComponent();
            var playedGameProcessor = new PlayedGameProcessor(_tracker, lvLiveGames);
            playedGameProcessor.AfterGamesAddedCallback += AfterGamesAddedCallback;

            pgMain.SelectedObject = Config.Settings; 
        }

        private void AfterGamesAddedCallback()
        {
            if (tsmiFollowSelected.Text == "Unfollow Selected" && lvLiveGames.SelectedItems.Count != 0)
                lvLiveGames.SelectedItems[0].EnsureVisible();
        }
        
        private PlayedGameResponse GetGame()
        {
            GameViewItem[] items;
            switch (Config.Settings.StrategyType)
            {
                case StrategyType.RandomGuessFromAll:
                case StrategyType.StartToFinishFromAll:
                    items = lvLiveGames.Items.Cast<GameViewItem>().
                        Where(item => item.GameResponse.SuccessfulGuessWasTaken).ToArray();
                    break;
                case StrategyType.RandomGuessFromSelected:
                case StrategyType.StartToFinishFromSelected:
                    items = lvLiveGames.SelectedItems.Cast<GameViewItem>().
                        Where(item => item.GameResponse.SuccessfulGuessWasTaken).ToArray();
                    break;
                default:
                    return null;
            }

            if (items.Length == 0)
                return null; 

            return items[Config.Random.Next(items.Length)].GameResponse;
        }
                                  
        private IStrategy GetStrategy(Guess[] guesses)
        {
            switch (Config.Settings.StrategyType)
            {
                case StrategyType.StartToFinishFromAll:
                case StrategyType.StartToFinishFromSelected:
                    return new StartToFinish(guesses);
                case StrategyType.RandomGuessFromAll:
                case StrategyType.RandomGuessFromSelected:
                    return new RandomPeice(guesses);
                default:
                    return null;
            }
        }

        private bool VerifyProperties()
        {
            try
            {
                var strategyType = Config.Settings.StrategyType;
                switch (strategyType)
                {
                    case StrategyType.RandomGuessFromAll:
                    case StrategyType.StartToFinishFromAll:
                        if (lvLiveGames.Items.Count == 0)
                            throw new Exception("Required strategies are not loaded.");
                        break;
                    case StrategyType.RandomGuessFromSelected:
                    case StrategyType.StartToFinishFromSelected:
                        if (lvLiveGames.SelectedItems.Count == 0)
                            throw new Exception("Required strategies are not selected.");
                        break;
                }

                if (string.IsNullOrWhiteSpace(Config.Settings.PlayerHash))
                    throw new Exception(string.Concat(nameof(Config.Settings.PlayerHash), " is empty."));

                if (string.IsNullOrWhiteSpace(Config.Settings.WithdrawAddress))
                    throw new Exception(string.Concat(nameof(Config.Settings.WithdrawAddress), " is empty."));

                if (Config.Settings.MaxMoves < 0 || Config.Settings.MaxMoves > 25)
                    throw new Exception(string.Concat(nameof(Config.Settings.MaxMoves), " is outside the range."));

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void tsmiCopyClick(object sender, EventArgs e)
        {
            if (lvLiveGames.SelectedItems.Count == 0)
                return;

            var item = lvLiveGames.SelectedItems[0] as GameViewItem;
            if (item == null)
                return;

            string toCopy;
            switch (((ToolStripMenuItem) sender).Name)
            {
                case "tsmiName": toCopy = item.SubItems[0].Text; break;
                case "tsmiBet": toCopy = item.SubItems[1].Text; break;
                case "tsmiWin": toCopy = item.SubItems[2].Text; break;
                case "tsmiProfit": toCopy = item.SubItems[3].Text; break;
                case "tsmiGameHash": toCopy = item.SubItems[4].Text; break;
                case "tsmiSecret": toCopy = item.SubItems[5].Text; break;
                default: return;
            }
            Clipboard.SetText(toCopy);
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            lvLiveGames.Items.Clear();
            tsmiFollowSelected.Text = "Follow";
        }

        private async void tsmiStartStrategy_Click(object sender, EventArgs e)
        {
            if (tsmiStartStrategy.Text == "Start Strategy")
            {
                if (!VerifyProperties())
                    return;

                pgMain.Enabled = false;
                tsmiStartStrategy.Text = "Stop Strategy";
                _currentPlayer = await _provider.CreatePlayer(Config.Settings.PlayerHash);

                while (true)
                {
                    var game = GetGame();            
                    var strategy = GetStrategy(game.Guesses);
                                                           
                    Mines mines;
                    if (Config.Settings.Mines != Mines.None)
                        mines = Config.Settings.Mines;
                    else
                        mines = (Mines) game.Bombs.Length;

                    _currentGame = await _currentPlayer.CreateGame(Config.Settings.Bits, mines);

                    var timesGussed = 0;
                    do
                    {
                        if (tsmiStartStrategy.Text != "Stop Strategy")
                            return;

                        var guess = strategy.Next();
                        if (guess == Guess.None)
                            break;

                        var gameResponse = await _currentGame.TakeGuess(strategy.Next());
                        await smgMain.UpdateMine(guess, gameResponse);

                        if (gameResponse.Outcome == "bomb")
                        {            
                            _currentGame = await _currentPlayer.CreateGame(Config.Settings.Bits, mines);         
                            break;
                        }                                                 

                        timesGussed++;            
                    } while (timesGussed + 1 < game.Guesses.Length &&
                             timesGussed != Config.Settings.MaxMoves);
                                                        
                    await Cashout();
                }
            }

            pgMain.Enabled = true;
            tsmiStartStrategy.Text = "Start Strategy";
        }

        private void tsmiWithdrawToWallet_Click(object sender, EventArgs e)
        {
            if (_currentPlayer == null)
                return;

            using (var withdrawForm = new WithdrawForm(_currentPlayer))
                withdrawForm.ShowDialog();
        }

        private void tsmiStartLoadingStrategy_Click(object sender, EventArgs e)
        {
            if (tsmiStartLoadingStrategy.Text == "Start Loading Strategy")
            {
                if (lvLiveGames.Items.Count != 0)
                {
                    var result = MessageBox.Show("Would you like to clear all previous live games?");
                    if (result == DialogResult.OK)
                       lvLiveGames.Clear();
                }
                _tracker.Start();
                tsmiStartLoadingStrategy.Text = "Stop Loading Strategy";
                return;
            }

            _tracker.Stop();
            tsmiStartLoadingStrategy.Text = "Start Loading Strategy";
        }
         
        private void tsmiFollowSelected_Click(object sender, EventArgs e)
        {
            if (tsmiFollowSelected.Text == "Follow Selected")
            {                 
                tsmiFollowSelected.Text = "Unfollow Selected";
                return;
            }         

            tsmiFollowSelected.Text = "Follow Selected";
        }
       
        private void tsmiViewDetailsForSelected_Click(object sender, EventArgs e)
        {
            if (lvLiveGames.SelectedItems.Count == 0)
                return;

            var gameViewItem = (GameViewItem) lvLiveGames.SelectedItems[0];     
            new PlayedGameForm(gameViewItem.GameResponse).Show();
        }

        private async void smgMain_OnCashoutClicked(object sender, EventArgs e)
        {
            await Cashout();
        }

        private async Task Cashout()
        {
            var response = await _currentGame.Cashout();
            if (response.Status == "success")
                await smgMain.ShowHiddenMines(response.Mines).ConfigureAwait(false);
        }
    }
}