using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource LastOrDefault<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            TSource last = default(TSource);
            foreach (TSource item in source) {
                last = item;
            }
            return last;
        }

        public static TSource LastOrDefault<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            TSource current = default(TSource);
            foreach (var element in source) {
                if (predicate(element)) {
                    current = element;
                }
            }
            return current;
        }

        // TODO: Use IList<T>[index] when applicable.
    }
}