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

            format += minutes < 10 ? string.Concat(0,minutes) : minutes.ToString();
            format += seconds < 10 ? string.Concat(0,seconds) : seconds.ToString();

            return format;
        }
        #endregion
    }
}
