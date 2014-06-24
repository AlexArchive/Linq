using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            return Except(first, second, null);
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            Ensure.IsNotNull(first, "first");
            Ensure.IsNotNull(second, "second");

            return ExceptIterator(first, second, comparer ?? EqualityComparer<TSource>.Default);
        }

        private static IEnumerable<TSource> ExceptIterator<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            var streamedElements = new HashSet<TSource>(second, comparer);
            foreach (var element in first) {
                if (streamedElements.Add(element)) {
                    yield return element;
                }
            }
        } 
    }
}