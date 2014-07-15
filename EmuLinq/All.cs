using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable  
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            foreach (var element in source) {
                if (!predicate(element))
                    return false;
            }
            return true;
        }
    }
}