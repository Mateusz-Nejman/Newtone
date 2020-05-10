using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public class Range
    {
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

        public static bool InRangeInt(int min, int max, int current)
        {
            return current >= min && current <= max;
        }
    }
}
