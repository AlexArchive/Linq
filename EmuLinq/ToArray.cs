using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource[] ToArray<TSource>(
            this IEnumerable<TSource> source)
        {
            Ensure.IsNotNull(source, "source");

            TSource[] array = new TSource[5];
            int count = 0;
            foreach (var element in source) {
                if (array.Length == count) {
                    Array.Resize(ref array, count * 2);
                }
                array[count] = element;
                count++;
            }
            Array.Resize(ref array, count);
            return array;
        }
    }
}