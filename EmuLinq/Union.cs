using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, 
            IEnumerable<TSource> second)
        {
            return Union(first, second, EqualityComparer<TSource>.Default);
        }
        
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            return UnionIterator(first, second, comparer ?? EqualityComparer<TSource>.Default);
        }

        private static IEnumerable<TSource> UnionIterator<TSource>(IEnumerable<TSource> first,
            IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var streamedElements = new HashSet<TSource>(comparer);

            foreach (var element in first)
            {
                if (streamedElements.Add(element))
                {
                    yield return element;
                }
            }

            foreach (var element in second)
            {
                if (streamedElements.Add(element))
                {
                    yield return element;
                }
            }
        }
    }
}