using System;

namespace AndGearbest
{
    internal class Utils
    {
        public static string CurrentTicks()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Ticks.ToString();
        }
    }
}