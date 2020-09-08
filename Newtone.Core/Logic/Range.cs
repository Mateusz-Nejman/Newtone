namespace Newtone.Core.Logic
{
    public class Range
    {
        #region Public Methods
        public static int GetRangeInt(int min, int max, int current)
        {
            if (min == max)
                return min;

            if (current < min)
            {
                int newC = current - min + 1;

                return max - newC;
            }

            if (current > max)
            {
                int newC = current - max - 1;
                return min + newC;
            }

            return current;
        }

        public static double GetRangeDbl(double min, double max, double current)
        {
            if (min == max)
                return min;

            if (current < min)
            {
                double newC = current - min + 1;

                return max - newC;
            }

            if (current > max)
            {
                double newC = current - max - 1;
                return min + newC;
            }

            return current;
        }

        public static bool InRangeInt(int min, int max, int current)
        {
            return current >= min && current <= max;
        }
        #endregion
    }
}
