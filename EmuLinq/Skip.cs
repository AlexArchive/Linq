using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Skip<TSource>(
            this IEnumerable<TSource> source,
            int count)
        {
            Ensure.IsNotNull(source, "source");
            return SkipIterator(source, count);
        }

        private static IEnumerable<TSource> SkipIterator<TSource>(
            IEnumerable<TSource> source,
            int count)
        {
            int enumeratedCount = 0;
            foreach (var element in source) {
                enumeratedCount += 1;
                if (enumeratedCount <= count) continue;
                yield return element;
            }
        }
    }
}