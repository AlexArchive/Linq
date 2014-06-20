using System;
using System.Collections;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source==null)
                throw new ArgumentNullException("source");

            var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return source;
            }

            return new[] { default( TSource ) };
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");


            var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return source;
            }

            return new[] { defaultValue };
        }

    }
}