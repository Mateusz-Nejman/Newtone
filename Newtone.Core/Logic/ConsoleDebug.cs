using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Newtone.Core.Logic
{
    public static class ConsoleDebug
    {
        #region Fields
        private static string savePath;
        #endregion
        #region Public Methods
        public static void WriteLine(string text)
        {
            string output = "[" + DateTime.Now.ToString() + "]: " + text;
            if (GlobalData.Current.IsDebugMode)
                Console.WriteLine(output);

            if (IsLogFile())
                WriteLog(output);
        }

        public static void WriteLine(Exception e)
        {
            string output = "[" + DateTime.Now.ToString() + "]: " + e;
            if (GlobalData.Current.IsDebugMode)
                Console.WriteLine(output);

            if (IsLogFile())
                WriteLog(output);
        }

        public static void WriteLine(object o)
        {
            string output = "[" + DateTime.Now.ToString() + "]: " + o;
            if (GlobalData.Current.IsDebugMode)
                Console.WriteLine(output);

            if (IsLogFile())
                WriteLog(output);
        }

        public static void SetLogfile(string filepath)
        {
            savePath = filepath;
        }
        #endregion
        #region Private Methods
        private static void WriteLog(string data)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(savePath, true);
                streamWriter.WriteLine(data);
                streamWriter.Close();
            }
            catch { }
        }

        private static bool IsLogFile()
        {
            return !string.IsNullOrEmpty(savePath);
        }
        #endregion
    }
}
