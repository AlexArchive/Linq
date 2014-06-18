using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext() == false)
            {
                return default(TSource);
            }

            TSource current = enumerator.Current;
            while (enumerator.MoveNext())
            {
                current = enumerator.Current;
            }
            return current;
        }

        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var enumerator = source.GetEnumerator();
            TSource current = default(TSource);
            bool gotMatch = false;
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    current = enumerator.Current;
                    gotMatch = true;
                }
            }

            if (gotMatch)
            {
                return current;
            }

            return default(TSource);
        }
    }
}