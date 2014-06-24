using System;
using System.Collections.Generic;

namespace EmuLinq
{   
    public static partial class Enumerable
    {
        public static TSource Last<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                TSource current = enumerator.Current;
                while (enumerator.MoveNext()) {
                    current = enumerator.Current;
                }
                return current;
            }
        }

        public static TSource Last<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            TSource current = default(TSource);
            bool gotMatch = false;
            foreach (var element in source) {
                if (predicate(element)) {
                    current = element;
                    gotMatch = true;
                } 
            }
            if (gotMatch) {
                return current;
            }
            throw new InvalidOperationException("Sequence contains no matching element");
        }
    }
}