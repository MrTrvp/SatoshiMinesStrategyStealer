using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;
using SatoshiMinesStrategyStealer.Core.Models;
using SatoshiMinesStrategyStealer.Core.Models.Enums;
using SatoshiMinesStrategyStealer.Core.Providers;
using SatoshiMinesStrategyStealer.UI.Controls;
using Timer = System.Timers.Timer;

namespace SatoshiMinesStrategyStealer.UI.Helpers
{
    public class PlayedGameProcessor : Queue<PlayedGameResponse>
    {
        public ListView ListView { get; }

        public event Action AfterGamesAddedCallback;

        public PlayedGameProcessor(LiveGameTracker tracker, ListView listView)
        {
            ListView = listView;
                                              
            tracker.LogUpdated += TrackerLogUpdated;
            tracker.GamePlayed += EnqueueGameResponse;  

            var timer = new Timer(100);
            timer.Elapsed += DequeueMany;
            timer.Start(); 
        }

        private void TrackerLogUpdated(LogType type, string message)
        {
            Debug.WriteLine($"[{type}] {message}");
        }

        public void EnqueueGameResponse(PlayedGameResponse gameResponse)
        {
            if (gameResponse.Guesses.Length < 0)
                return;

            Console.WriteLine(gameResponse.Profit);
            if (gameResponse.Profit == 0)
                return;

            Enqueue(gameResponse);
        }

        public void DequeueMany(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (Count == 0)
                return;

            var logAction = new Action(() =>
            {
                if (ListView.Items.Count == 200000)
                    ListView.Items.Clear();

                for (var i = 0; i < Count; i++)
                {
                    var currentGameResponse = Dequeue();                       
                    ListView.Items.Insert(0, new GameViewItem(currentGameResponse));  
                }
            });

            ListView.Invoke(logAction);
            AfterGamesAddedCallback?.Invoke();
        }
    }
}             