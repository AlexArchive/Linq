using System.Collections.Generic;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");

            return SelectManyIterator(source, selector);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(
            IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var element in source) {
                foreach (var subElement in selector(element)) {
                    yield return subElement;
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, 
            IEnumerable<TResult>> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");

            return SelectManyIterator(source, selector);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(
            IEnumerable<TSource> source,
            Func<TSource, int, 
            IEnumerable<TResult>> selector)
        {
            int index = 0;
            foreach (var element in source) {
                foreach (var subElement in selector(element, index)) {
                    yield return subElement;
                }
                index++;
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> collectionSelector,
            Func<TSource, TResult, TResult> resultSelector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(collectionSelector, "collectionSelector");
            Ensure.IsNotNull(resultSelector, "resultSelector");

            return SelectManyIterator(source, collectionSelector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(
            IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> collectionSelector,
            Func<TSource, TResult, TResult> resultSelector)
        {
            foreach (var element in source) {
                foreach (var subElement in collectionSelector(element)) {
                    yield return resultSelector(element, subElement);
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> collectionSelector,
            Func<TSource, TResult, TResult> resultSelector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(collectionSelector, "collectionSelector");
            Ensure.IsNotNull(resultSelector, "resultSelector");

            return SelectManyIterator(source, collectionSelector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(
            IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> collectionSelector, 
            Func<TSource, TResult, TResult> resultSelector)
        {
            int index = 0;
            foreach (var element in source) {
                foreach (var subElement in collectionSelector(element, index)) {
                    yield return resultSelector(element, subElement);
                }
                index++;
            }
        }
    }
}