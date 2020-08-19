using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public static class ConsoleDebug
    {
        #region Fields
        private static string filter = "";
        #endregion
        #region Public Methods
        public static void WriteLine(string text)
        {
            if (GlobalData.Current.IsDebugMode && text.Contains(filter))
                Console.WriteLine(text);
        }

        public static void WriteLine(Exception e)
        {
            if (GlobalData.Current.IsDebugMode && e.Message.Contains(filter))
                Console.WriteLine(e);
        }

        public static void WriteLine(object o)
        {
            if (GlobalData.Current.IsDebugMode)
                Console.WriteLine(o);
        }

        public static void SetFilter(string newFilter)
        {
            filter = newFilter;
        }
        #endregion
    }
}
