using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var element in source)
            {
                return element;
            }

            throw new InvalidOperationException();
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (var element in source)
            {
                if (predicate(element))
                    return element;
            }

            throw new InvalidOperationException();
        }
    }
}