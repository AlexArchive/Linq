using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource Single<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                var single = enumerator.Current;
                if (enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains more than one element");
                }
                return single;
            }
        }

        public static TSource Single<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains no matching element");
                }
                var single = enumerator.Current;
                if (!predicate(single)) {
                    throw new InvalidOperationException("Sequence contains no matching element");
                }
                if (enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains more than one matching element");
                }
                return single;
            }
        }
    }
}