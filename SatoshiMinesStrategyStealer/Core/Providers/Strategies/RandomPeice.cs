using System.Collections.Generic;
using System.Linq;
using SatoshiMinesStrategyStealer.Core.Models.Enums;

namespace SatoshiMinesStrategyStealer.Core.Providers.Strategies
{
    public class RandomPeice : IStrategy
    {                                 
        public List<Guess> GameGuesses { get; set; }

        public List<Guess> GuessesTaken { get; set; }

        public RandomPeice(IEnumerable<Guess> gameGuesses)
        {                                           
            GameGuesses = gameGuesses.ToList();
            GuessesTaken = new List<Guess>();
        }

        public Guess Next()
        {
            var possibleGuesses = GameGuesses.Where(guess => !GuessesTaken.Contains(guess)).ToArray();
            if (possibleGuesses.Length == 0)
                return Guess.None;

            var chosenGuess = possibleGuesses[Config.Random.Next(possibleGuesses.Length)];

            GuessesTaken.Add(chosenGuess);
            return chosenGuess;
        }
    }
}