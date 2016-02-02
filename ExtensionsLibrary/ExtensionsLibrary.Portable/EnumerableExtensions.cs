using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsLibrary
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Linq style "foreach" loop
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null) return;

            foreach (var item in items)
            {
                action(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return items == null || !items.Any();
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> enumerable, T item)
        {
            yield return item;
            foreach (T obj in enumerable)
                yield return obj;
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T item)
        {
            foreach (T obj in enumerable)
                yield return obj;
            yield return item;
        }

        public static int IndexOf<T>(this IEnumerable<T> enumerable, T item)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            int num = 0;
            foreach (T obj in enumerable)
            {
                if (object.Equals((object)obj, (object)item))
                    return num;
                ++num;
            }
            return -1;
        }

        public static int IndexOf<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            int num = 0;
            foreach (T obj in enumerable)
            {
                if (predicate(obj))
                    return num;
                ++num;
            }
            return -1;
        }
    }
}
