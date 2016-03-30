using System.Collections.Generic;
using System.Linq;
using SatoshiMinesStrategyStealer.Core.Models.Enums;

namespace SatoshiMinesStrategyStealer.Core.Providers.Strategies
{
    public class StartToFinish : IStrategy
    {                                               
        public List<Guess> GameGuesses { get; set; }

        public List<Guess> GuessesTaken { get; set; }

        private int _index;

        public StartToFinish(IEnumerable<Guess> gameGuesses)
        {                             
            GameGuesses = gameGuesses.ToList();
            GuessesTaken = new List<Guess>();
        }

        public Guess Next()
        {
            var chosenGuess = GameGuesses[_index];
            if (_index++ > GameGuesses.Count)
                return Guess.None;

            GuessesTaken.Add(chosenGuess);
            return chosenGuess;
        }
    }
}