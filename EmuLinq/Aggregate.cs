using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, 
            Func<TSource, TSource, TSource> func)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext()) throw new InvalidOperationException();

                TSource result = enumerator.Current;

                while (enumerator.MoveNext())
                {
                    result = func(result, enumerator.Current);
                }

                return result;
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            foreach (var element in source)
            {
                seed = func(seed, element);
            }

            return seed;
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed, 
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");
            if (resultSelector == null) throw new ArgumentNullException("resultSelector");

            foreach (var element in source)
            {
                seed = func(seed, element);
            }

            return resultSelector(seed);
        }
    }
}