using System;

namespace SatoshiMinesStrategyStealer.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GetBetween(this string content, string begin, string end)
        {
            var start = content.IndexOf(begin, StringComparison.Ordinal) + begin.Length;
            var last = content.IndexOf(end, start, StringComparison.Ordinal) - start;

            return content.Substring(start, last);
        }
    }
}   