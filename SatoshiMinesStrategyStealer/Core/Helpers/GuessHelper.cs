using System.Linq;                                
using SatoshiMinesStrategyStealer.Core.Models.Enums;

namespace SatoshiMinesStrategyStealer.Core.Helpers
{
    public static class GuessHelper
    {
        public static Guess[] MessageToGuesses(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return new Guess[] { };

            return message.Split('-').Select(split => (Guess) int.Parse(split)).ToArray();
        }                      
    }
}