using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            return WhereIterator(source, predicate);
        }

        private static IEnumerable<TSource> WhereIterator<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            foreach (TSource element in source) {
                if (predicate(element)) {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            return WhereIterator(source, predicate);
        }

        private static IEnumerable<TSource> WhereIterator<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int index = -1;
            foreach (var element in source) {
                index++;
                if (predicate(element, index)) {
                    yield return element;
                }
            }
        }
    }
}