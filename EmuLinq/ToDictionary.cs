using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IDictionary<TKey, TSource> ToDictionary<TKey, TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return source.ToDictionary(keySelector, null);
        }

        public static IDictionary<TKey, TSource> ToDictionary<TKey, TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer) 
        {
            return source.ToDictionary(keySelector, element => element, comparer);
        }

        public static IDictionary<TKey, TElement> ToDictionary<TKey, TSource, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            return source.ToDictionary(keySelector, elementSelector, null);
        }

        public static IDictionary<TKey, TElement> ToDictionary<TKey, TSource, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(keySelector, "keySelector");
            Ensure.IsNotNull(elementSelector, "elementSelector");

            var dictionary = new Dictionary<TKey, TElement>(comparer);
            foreach (var element in source) {
                dictionary.Add(keySelector(element), elementSelector(element));
            }
            return dictionary;
        }
    }
}