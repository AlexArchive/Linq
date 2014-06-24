using System;
using System.Collections.Generic;

namespace EmuLinq
{

    public static partial class Enumerable
    {
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            using (var enumerator = source.GetEnumerator())
            {

                if (!enumerator.MoveNext())
                {
                    return default(TSource);
                }

                var single = enumerator.Current;

                if (enumerator.MoveNext())
                {
                    throw new InvalidOperationException();
                }

                return single;
            }
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return default(TSource);
                }

                var single = enumerator.Current;

                if (!predicate(single))
                    return default(TSource);

                if (enumerator.MoveNext())
                {
                    throw new InvalidOperationException();
                }

                return single;
            }
        }
    }

}