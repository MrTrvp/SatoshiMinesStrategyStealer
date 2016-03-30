using System.Windows.Forms;
using SatoshiMinesStrategyStealer.Core.Models;

namespace SatoshiMinesStrategyStealer.UI.Forms
{
    public partial class PlayedGameForm : Form
    {
        public PlayedGameForm(PlayedGameResponse gameResponse)
        {
            InitializeComponent();
            ShowGameDetails(gameResponse);
        }

        private void ShowGameDetails(PlayedGameResponse gameResponse)
        {
            Text = string.Format(Text, gameResponse.Name, gameResponse.Id, gameResponse.RandomString);
            smgMain.ShowPlayedGame(gameResponse);
            plMines.RealText = gameResponse.Bombs.Length.ToString();
            plGuesses.RealText = gameResponse.Guesses.Length.ToString();
            plBet.RealText = gameResponse.Bet;
            plWon.RealText = gameResponse.LastStake; 
        }

        private void PlayedGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}       