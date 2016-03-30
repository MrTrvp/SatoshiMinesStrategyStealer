using System.ComponentModel;
using SatoshiMinesStrategyStealer.Core.Models.Enums;
using SatoshiMinesStrategyStealer.UI.Models.Enums;

namespace SatoshiMinesStrategyStealer.UI.Models
{
    public class SatoshiMinesSettings
    {
        [DisplayName("Strategy Type")]
        [Description("Indicates the strategy type to use.")]
        public StrategyType StrategyType { get; set; } = StrategyType.RandomGuessFromAll;

        [DisplayName("Max Moves*")]
        [Description("Number of moves to take before cashing out.")]
        public int MaxMoves { get; set; } = 5;

        [DisplayName("Player Hash*")]
        [Description("Player hash to play games on.")]
        public string PlayerHash { get; set; }

        [DisplayName("Withdraw Address*")]
        [Description("Address to send money to.")]
        public string WithdrawAddress { get; set; }

        [DisplayName("Balance")]
        [Description("Balance of the player.")]
        public int Balance { get; set; }

        [DisplayName("Bits*")]
        [Description("Bits to bet with.")]
        public int Bits { get; set; } = 30;
           
        [DisplayName("Mines*")]
        [Description("Mines to be challenged with. None to use games's mines.")]
        public Mines Mines { get; set; } = Mines.Three;
    }
}