using System;
using System.Linq;
using SatoshiMinesStrategyStealer.Core.Models.Enums;
using SatoshiMinesStrategyStealer.UI.Models;

namespace SatoshiMinesStrategyStealer
{
    public static class Config
    {
        public readonly static SatoshiMinesSettings Settings
            = new SatoshiMinesSettings();

        public static readonly Guess[] AllGuesses
            = Enum.GetValues(typeof (Guess)).Cast<Guess>().ToArray();

        public readonly static Random Random
            = new Random();
    }
}