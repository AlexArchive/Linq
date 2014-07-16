using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> TakeWhile<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");
            return TakeWhileIterator(source, predicate);
        }

        private static IEnumerable<TSource> TakeWhileIterator<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int index = 0;
            foreach (var element in source) {
                if (!predicate(element, index)) break;
                yield return element;
                index += 1;
            }
        }

        private static IEnumerable<TSource> TakeWhileIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var element in source) {
                if (!predicate(element)) break;
                yield return element;
            }
        }

        public static IEnumerable<TSource> TakeWhile<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");
            return TakeWhileIterator(source, predicate);
        }
    }
}