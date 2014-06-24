using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource FirstOrDefault<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            foreach (var element in source) {
                return element;
            }
            return default(TSource);
        }

        public static TSource FirstOrDefault<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            foreach (var element in source) {
                if (predicate(element)) {
                    return element;
                }
            }
            return default(TSource);
        }
    }
}