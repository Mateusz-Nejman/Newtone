using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Logic
{
    public class Range
    {
        public static int GetRangeInt(int min, int max, int current)
        {
            if (min == max)
                return min;

            current = Math.Abs(current);
            if(current < min)
            {
                int newC = current - min;

                return max - newC;
            }
            
            if(current > max)
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