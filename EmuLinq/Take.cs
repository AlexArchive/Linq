using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Take<TSource>(
            this IEnumerable<TSource> source, 
            int count)
        {
            Ensure.IsNotNull(source, "source");
            return TakeIterator(source, count);
        }

        private static IEnumerable<TSource> TakeIterator<TSource>(
            IEnumerable<TSource> source, 
            int count)
        {
            int elementsStreamed = 0;
            using (var enumerator = source.GetEnumerator()) {
                while (enumerator.MoveNext()) {
                    elementsStreamed += 1;
                    yield return enumerator.Current;
                    if (elementsStreamed == count) yield break;
                }
            }
        }
    }
}