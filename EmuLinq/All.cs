using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable  
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (var element in source)
            {
                if (!predicate(element))
                    return false;
            }

            return true;
        }
    }
}