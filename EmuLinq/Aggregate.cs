using System;
using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static TSource Aggregate<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> func)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(func, "func");

            using (var enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                TSource result = enumerator.Current;
                while (enumerator.MoveNext()) {
                    result = func(result, enumerator.Current);
                }
                return result;
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            return Aggregate(source, seed, func, x => x);
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(func, "func");
            Ensure.IsNotNull(resultSelector, "resultSelector");

            foreach (var element in source) {
                seed = func(seed, element);
            }
            return resultSelector(seed);
        }
    }
}