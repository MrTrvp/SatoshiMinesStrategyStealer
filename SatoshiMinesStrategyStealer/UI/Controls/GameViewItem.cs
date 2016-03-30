using System.Drawing;
using System.Windows.Forms;
using SatoshiMinesStrategyStealer.Core.Models;

namespace SatoshiMinesStrategyStealer.UI.Controls
{
    public class GameViewItem : ListViewItem
    {
        public PlayedGameResponse GameResponse { get; }

        public GameViewItem(PlayedGameResponse gameResponse)
        {
            GameResponse = gameResponse;
            UseItemStyleForSubItems = false;

            Text = gameResponse.Name;     
            SubItems.AddRange(new []
            {
                gameResponse.Bet,
                (double.Parse(gameResponse.LastStake) * 1000000).ToString("N0"),
                gameResponse.Profit.ToString("+#;-#;0") + " Bits",
                gameResponse.Hash,
                GetSecret()
            });
                       
            SubItems[3].ForeColor = GetProfileColor();
        }

        public string GetSecret()
        {
            return string.Concat(GameResponse.Bombs, GameResponse.RandomString);
        }

        private Color GetProfileColor()
        {                              
            if (GameResponse.Practice != "0")
                return Color.Gray;

            return GameResponse.Profit < 0 ? Color.Red : Color.Green;
        }
    }
}