using System.Collections;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var element in source)
            {
                var intermediates = selector(element);
                foreach (var intermediate in intermediates)
                {
                    yield return intermediate;
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> selector)
        {
            int index = 0;
            foreach (var element in source)
            {
                var intermediates = selector(element, index);
                foreach (var intermediate in intermediates)
                {
                    yield return intermediate;
                }
                index++;
            }

        }
        
    }
}