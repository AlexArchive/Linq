using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var enumerator = source.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            var single = enumerator.Current;

            if (enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            return single;
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var enumerator = source.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            var single = enumerator.Current;

            if (!predicate(single)) throw new InvalidOperationException();

            if (enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            return single;
        }


    }
}