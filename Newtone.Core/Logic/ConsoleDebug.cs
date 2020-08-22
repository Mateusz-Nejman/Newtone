using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public static class ConsoleDebug
    {
        #region Public Methods
        public static void WriteLine(string text)
        {
            if (GlobalData.Current.IsDebugMode)
                Console.WriteLine(text);
        }

        public static void WriteLine(Exception e)
        {
            if (GlobalData.Current.IsDebugMode)
                Console.WriteLine(e);
        }

        public static void WriteLine(object o)
        {
            if (GlobalData.Current.IsDebugMode)
                Console.WriteLine(o);
        }
        #endregion
    }
}
