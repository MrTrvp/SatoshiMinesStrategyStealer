using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SatoshiMinesStrategyStealer.Core.Providers
{
    public class SatoshiMinesProvider : IDisposable
    {
        public const string Host = "https://satoshimines.com/";

        private readonly HttpClient _client;

        public SatoshiMinesProvider()
        {
            _client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false,
                UseProxy = false
            })
            {
                BaseAddress = new Uri(Host)
            };
        }

        public async Task<Player> CreatePlayer(string playerHash = null)
        {                    
            if (!string.IsNullOrWhiteSpace(playerHash))
            {
                return new Player(_client, true)
                {
                    PlayerHash = playerHash,  
                    BdValue = await GetBdValue(playerHash)
                };
            }

            using (var response = await _client.GetAsync("/newplayer.php"))
            {
                var location = response.Headers.Location.ToString();

                var playerHashMatch = Regex.Match(location, "/play/([^/]+)/#DONT_SHARE_URL");
                if (!playerHashMatch.Success)
                    return null;

                playerHash = playerHashMatch.Groups[1].Value;
                return new Player(_client)
                {
                    PlayerHash = playerHash,
                    BdValue = await GetBdValue(playerHash, location)
                };
            }    
        }

        private async Task<string> GetBdValue(string playerHash, string location = null)
        {
            if (location == null)
                location = $"/play/{playerHash}/#DONT_SHARE_URL";

            var response = await _client.GetAsync(location);
            var content = await response.Content.ReadAsStringAsync();

            var bdValueMatch = Regex.Match(content, "bdval = '(\\d+)'");
            return !bdValueMatch.Success ? null : bdValueMatch.Groups[1].Value;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}