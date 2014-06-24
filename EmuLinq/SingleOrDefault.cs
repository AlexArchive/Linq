using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource SingleOrDefault<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    return default(TSource);
                }
                var single = enumerator.Current;
                if (enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains more than one element");
                }
                return single;
            }
        }

        public static TSource SingleOrDefault<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    return default(TSource);
                }
                var single = enumerator.Current;
                if (!predicate(single)) {
                    return default(TSource);
                }
                if (enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains more than one matching elemen");
                }
                return single;
            }
        }
    }
}