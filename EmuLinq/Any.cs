using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static bool Any<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            using (var enumerator = source.GetEnumerator()) {
                return enumerator.MoveNext();
            }
        }

        public static bool Any<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(predicate, "predicate");

            foreach (var element in source) {
                if (predicate(element)) {
                    return true;
                }
            }
            return false;
        }
    }
}