using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> SkipWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");
            return SkipWhileIterator(source, predicate);
        }

        private static IEnumerable<TSource> SkipWhileIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var element in source) {
                if (predicate(element)) continue;
                yield return element;
            }
        }

        public static IEnumerable<TSource> SkipWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");
            return SkipWhileIterator(source, predicate);
        }

        private static IEnumerable<TSource> SkipWhileIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int index = 0;
            foreach (var element in source) {
                if (predicate(element, index++)) continue;
                yield return element;
            }
        }
    }
}