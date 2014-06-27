using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static List<TSource> ToList<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            return new List<TSource>(source);
        }
    }
}