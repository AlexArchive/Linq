using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static long LongCount<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            long count = 0;
            foreach (var element in source) {
                checked { count++; }
            }
            return count;
        }

        public static long LongCount<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            long count = 0;
            foreach (var element in source) {
                if (predicate(element)) {
                    checked { count++; }
                }
            }
            return count;
        }
    }
}