﻿using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using SatoshiMinesStrategyStealer.Core.Helpers;
using SatoshiMinesStrategyStealer.Core.Models;
using SatoshiMinesStrategyStealer.Core.Models.Enums;

namespace SatoshiMinesStrategyStealer.Core.Providers
{
    public class Game
    {      
        public GameResponse GameResponse { get; }   
        private readonly HttpClient _client;

        public Game(GameResponse gameResponse, HttpClient client)
        {
            GameResponse = gameResponse;
            _client = client;
        }

        public async Task<GuessResponse> TakeGuess(Guess guess)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/action/checkboard.php")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"game_hash", GameResponse.GameHash},
                    {"guess", ((byte) guess).ToString(CultureInfo.InvariantCulture)},
                    {"v04", "1" }
                })
            };

            using (var response = await _client.SendAsync(request))
            {
                var content = await response.Content.ReadAsStringAsync();    
                return JsonHelper.Deserialize<GuessResponse>(content);
            }   
        }

        public async Task<CashoutResponse> Cashout()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/action/cashout.php")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"game_hash", GameResponse.GameHash}, 
                })
            };

            using (var response = await _client.SendAsync(request))
            {          
                var content = await response.Content.ReadAsStringAsync();
                return JsonHelper.Deserialize<CashoutResponse>(content);
            } 
        }
    }
}