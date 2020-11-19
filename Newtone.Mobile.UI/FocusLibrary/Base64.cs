using System;

namespace Nejman.Xamarin.FocusLibrary
{
    internal static class Base64
    {
        public static byte[] FromString(string baseText)
        {
            return Convert.FromBase64String(baseText);
        }
    }
}
