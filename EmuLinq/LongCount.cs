using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static long LongCount<TSource>(this IEnumerable<TSource> source)
        {
            if (source ==null)
                throw new ArgumentNullException();

            long count = 0;
            foreach (var element in source)
            {
                count++;
            }
            return count;
        }

        public static long LongCount<TSource>(this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException();

            if (predicate == null)
                throw new ArgumentNullException();

            var filteredSource = source.Where(predicate);
            return filteredSource.LongCount();
        }
    }
}