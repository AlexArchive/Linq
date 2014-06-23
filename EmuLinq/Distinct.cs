using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            return Distinct(source, EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, 
            IEqualityComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return DistinctIterator(source, comparer ?? EqualityComparer<TSource>.Default);
        }

        private static IEnumerable<TSource> DistinctIterator<TSource>(this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            var streamedElements = new HashSet<TSource>(comparer);

            foreach (var element in source)
            {
                if (streamedElements.Add(element))
                {
                    yield return element;
                }
            }
        }
    }
}