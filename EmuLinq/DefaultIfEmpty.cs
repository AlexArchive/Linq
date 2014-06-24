using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
            this IEnumerable<TSource> source)
        {
            return DefaultIfEmpty(source, default(TSource));
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
            this IEnumerable<TSource> source, 
            TSource defaultValue)
        {
            Ensure.IsNotNull(source, "source");

            using (var enumerator = source.GetEnumerator()) {
                if (enumerator.MoveNext()) {
                    return source;
                }
            }
            return new[] { defaultValue };
        }
    }
}