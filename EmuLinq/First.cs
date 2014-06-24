using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource First<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            foreach (var element in source) {
                return element;
            }
            throw new InvalidOperationException("Sequence contains no elements");
        }

        public static TSource First<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            foreach (var element in source) {
                if (predicate(element))
                    return element;
            }
            throw new InvalidOperationException("Sequence contains no matching element");
        }
    }
}