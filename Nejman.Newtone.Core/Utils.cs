using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core
{
    internal static class Utils
    {
        private static Random random;

        public static Random Random
        {
            get
            {
                if(random == null)
                {
                    random = new Random();
                }

                return random;
            }
        }

        public static int GetRandom(int max)
        {
            return Random.Next(0, max);
        }
    }
}
