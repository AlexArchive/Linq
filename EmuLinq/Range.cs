using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            // why do I need to + 1 here?
            long maximum = ((long) start) + count - 1;

            if (count < 0 || maximum > Int32.MaxValue)
                throw new ArgumentOutOfRangeException("count");

            return RangeImpl(start, count);
        }

        private static IEnumerable<int> RangeImpl(int start, int count)
        {
            for (int i = 0; i < count; i++)
                yield return start + i;
        }
    }
}