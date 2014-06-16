using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial  class Enumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var count = 0;
            foreach (var element in source)
            {
                checked { count++; }
            }
            return count;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var filteredSource = source.Where(predicate);
            return filteredSource.Count();
        }

        // use ICollection.Count when applicable for better performance.
    }
}