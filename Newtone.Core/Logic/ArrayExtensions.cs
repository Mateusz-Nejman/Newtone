using System;
using System.Collections.Generic;

namespace Newtone.Core.Logic
{
    public static class ArrayExtensions
    {
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            foreach (T element in array)
                action(element);
        }

        public static void ForEach<T>(this Dictionary<string, T>.KeyCollection collection, Action<string> action)
        {
            foreach (string key in collection)
                action(key);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T element in enumerable)
                action(element);
        }
    }
}
