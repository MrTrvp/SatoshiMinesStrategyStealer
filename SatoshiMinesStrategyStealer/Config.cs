using System;                                       
using SatoshiMinesStrategyStealer.UI.Models;

namespace SatoshiMinesStrategyStealer
{
    public static class Config
    {
        public readonly static SatoshiMinesSettings Settings
            = new SatoshiMinesSettings();

        public readonly static Random Random
            = new Random();
    }
}