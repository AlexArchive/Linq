using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            long maximum = ((long) start) + count - 1;
            if (count < 0 || maximum > Int32.MaxValue)
                throw new ArgumentOutOfRangeException("count");

            return RangeIterator(start, count);
        }

        private static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (int i = 0; i < count; i++) {
                yield return start + i;
            }
        }
    }
}