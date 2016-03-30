using System.Collections.Generic;
using SatoshiMinesStrategyStealer.Core.Models.Enums;

namespace SatoshiMinesStrategyStealer.Core.Providers.Strategies
{
    public interface IStrategy
    {
        List<Guess> GuessesTaken { get; set; }

        List<Guess> GameGuesses { get; set; }

        Guess Next();
    }
}