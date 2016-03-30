using System.Drawing;
using SatoshiMinesStrategyStealer.Core.Models.Enums;
using SatoshiMinesStrategyStealer.UI.Models.Enums;

namespace SatoshiMinesStrategyStealer.UI.Models
{
    public class GuessTile
    {
        public Guess Guess { get; set; }

        public Rectangle Rectangle { get; set; } = Rectangle.Empty;

        public TileType Type { get; set; } = TileType.Unclicked;

        public GuessTile(Guess guess)
        {
            Guess = guess;
        }
    }
}