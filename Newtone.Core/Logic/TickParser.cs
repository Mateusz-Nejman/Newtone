using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public class TickParser
    {
        #region Public Methods
        public static string FormatTick(double ticks)
        {
            int totalSeconds = (int)ticks;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds - (minutes * 60);

            string format = "";

            format += minutes < 10 ? $"0{minutes}:" : $"{minutes}";
            format += seconds < 10 ? $"0{seconds}" : $"{seconds}";

            return format;
        }
        #endregion
    }
}
