using System.Runtime.Serialization;
using SatoshiMinesStrategyStealer.Core.Helpers;
using SatoshiMinesStrategyStealer.Core.Models.Enums; 

namespace SatoshiMinesStrategyStealer.Core.Models
{
    [DataContract]
    public class PlayedGameResponse
    {
        [DataMember(Name = "game_id")]
        public string Id { get; set; }

        [DataMember(Name = "random_string")]
        public string RandomString { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; } 

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "game_hash")]
        public string Hash { get; set; }

        [DataMember(Name = "bombs_encrypted")]
        public string BombsEncrypted { get; set; }

        [DataMember(Name = "bet")]
        public string Bet { get; set; }

        [DataMember(Name = "stake")]
        public string Stake { get; set; }

        [DataMember(Name = "last_stake")]
        public string LastStake { get; set; }

        [DataMember(Name = "next")]
        public string Next { get; set; }

        [DataMember(Name = "practice")]
        public string Practice { get; set; }

        [DataMember(Name = "bombs")]
        public string BombsString { get; set; }

        public Guess[] Bombs { get; set; }

        [DataMember(Name = "last_bet")]
        public string LastBet { get; set; }

        [DataMember(Name = "guesses")]
        public string GuessesString { get; set; }

        public int Profit { get; set; }

        public bool SuccessfulGuessWasTaken { get; set; }

        public Guess[] Guesses { get; set; }

        private static PlayedGameResponse SetExtraGameResponseFields(PlayedGameResponse gameResponse)
        {
            gameResponse.Profit = CalculateProfit(gameResponse);
            gameResponse.Bombs = GuessHelper.MessageToGuesses(gameResponse.BombsString);
            gameResponse.Guesses = GuessHelper.MessageToGuesses(gameResponse.GuessesString);
            gameResponse.SuccessfulGuessWasTaken = gameResponse.Guesses.Length != 0;

            return gameResponse;
        }
              
        private static int CalculateProfit(PlayedGameResponse gameResponse)
        {
            var bet = double.Parse(gameResponse.Bet);
            var stake = double.Parse(gameResponse.LastStake);
            var winMultiplier = gameResponse.Status == "win" ? 1 : 0;

            return (int)((bet - stake * winMultiplier) * -1000000);
        }

        public static PlayedGameResponse GameResponseFromMessage(object message)
        {
            var gameResponse = JsonHelper.Deserialize<PlayedGameResponse>(message.ToString());
            return SetExtraGameResponseFields(gameResponse);
        }

        public static PlayedGameResponse[] GameResponsesFromMessage(object message)
        {
            var gameResponses = JsonHelper.Deserialize<PlayedGameResponse[]>(message.ToString());
            foreach (var gameResponse in gameResponses)
                SetExtraGameResponseFields(gameResponse);

            return gameResponses;
        }
    }
}