using System.Collections.Generic;
using System.Web;
using Quobject.SocketIoClientDotNet.Client;         
using SatoshiMinesStrategyStealer.Core.Models;
using SatoshiMinesStrategyStealer.Core.Models.Enums;

namespace SatoshiMinesStrategyStealer.Core.Providers
{
    public class LiveGameTracker
    {                                  
        private Socket _socket;

        private bool _connected;

        public delegate void LogUpdateHandler(LogType type, string message);
        public event LogUpdateHandler LogUpdated;

        public delegate void GamePlayedHandler(PlayedGameResponse gameResponse);
        public event GamePlayedHandler GamePlayed;

        private void InternalLogUpdated(LogType logType, string message)
        {
            LogUpdated?.Invoke(logType, message);
        }

        private void InternalGamePlayed(PlayedGameResponse game)
        {
            game.Name = HttpUtility.HtmlDecode(game.Name);
            InternalLogUpdated(LogType.Game, game.Name);

            GamePlayed?.Invoke(game);
        }

        private void InternalGamePlayed(IEnumerable<PlayedGameResponse> games)
        {
            foreach (var game in games)
                InternalGamePlayed(game);
        }
           
        public void Start()
        {
            if (_connected)
                return;
                                       
            _socket = IO.Socket(SatoshiMinesProvider.Host);  

            _socket.On("game", message =>
            {            
                InternalGamePlayed(PlayedGameResponse.GameResponseFromMessage(message));
            });

            _socket.On("game_log", message =>
            {                                                                             
                InternalGamePlayed(PlayedGameResponse.GameResponsesFromMessage(message));
            });

            _connected = true;        
            InternalLogUpdated(LogType.Socket, "Socket registered.");
        }

        public void Stop()
        {
            _socket.Disconnect();
            _connected = false;
        }
    }

    public enum LogType
    {
        Socket,
        Game
    }

    #region Json

    #endregion
}