using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Concat<TSource>(
            this IEnumerable<TSource> first, 
            IEnumerable<TSource> second)
        {
            Ensure.IsNotNull(first, "first");
            Ensure.IsNotNull(second, "second");

            return ConcatIterator(first, second);
        }

        private static IEnumerable<TSource> ConcatIterator<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            foreach (var element in first) {
                yield return element;
            }
            first = null;
            foreach (var element in second) {
                yield return element;
            }
        }
    }
}