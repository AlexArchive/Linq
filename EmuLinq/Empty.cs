using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Empty<TResult>()
        {
            return EmptyHolder<TResult>.Array;
        }

        private static class EmptyHolder<T>
        {
            internal static readonly T[] Array = new T[0];
        }
    }
}