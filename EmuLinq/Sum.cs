using System;
using System.Collections.Generic;
using System.Timers;

namespace EmuLinq
{
    public static partial class Enumerable
    {
        #region Int32
        public static int Sum(
            this IEnumerable<int> source)
        {
            return Sum(source, number => number);
        }

        public static int? Sum(
            this IEnumerable<int?> source)
        {
            return Sum(source, number => number);
        }

        public static int Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");

            int sum = 0;
            foreach (var element in source)
            {
                checked
                {
                    sum += selector(element);
                }
            }
            return sum;
        }

        public static int? Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int?> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");

            int sum = 0;
            foreach (var element in source)
            {
                checked
                {
                    sum += selector(element).GetValueOrDefault();
                }
            }
            return sum;
        }
        #endregion

        #region Int64
        public static long Sum(
            this IEnumerable<long> source)
        {
            return Sum(source, number => number);
        }

        public static long? Sum(
            this IEnumerable<long?> source)
        {
            return Sum(source, number => number);
        }

        public static long Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");

            long sum = 0;
            foreach (var element in source)
            {
                checked
                {
                    sum += selector(element);
                }
            }
            return sum;
        }

        public static long? Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, long?> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");
            long sum = 0;
            foreach (var element in source)
            {
                checked
                {
                    sum += selector(element).GetValueOrDefault();
                }
            }
            return sum;
        }
        #endregion

        #region Double
        public static double Sum(
            this IEnumerable<double> source)
        {
            return Sum(source, number => number);
        }

        public static double? Sum(
            this IEnumerable<double?> source)
        {
            return Sum(source, number => number);
        }

        public static double Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");
            double sum = 0;
            foreach (var element in source)
            {
                sum += selector(element);
            }

            return sum;
        }

        public static double? Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, double?> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");
            double? sum = 0;
            foreach (var element in source)
            {
                sum += selector(element).GetValueOrDefault();
            }
            return sum;
        }
        #endregion

        #region Float
        public static float Sum(
            this IEnumerable<float> source)
        {
            return Sum(source, number => number);
        }

        public static float? Sum(
            this IEnumerable<float?> source)
        {
            return Sum(source, number => number);
        }

        public static float Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");
            float sum = 0;
            foreach (var element in source)
            {
                sum += selector(element);
            }

            return sum;
        }

        public static float? Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float?> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");
            float? sum = 0;
            foreach (var element in source)
            {
                sum += selector(element).GetValueOrDefault();
            }
            return sum;
        }
        #endregion

        #region Decimal
        public static decimal Sum(
            this IEnumerable<decimal> source)
        {
            return Sum(source, number => number);
        }

        public static decimal? Sum(
            this IEnumerable<decimal?> source)
        {
            return Sum(source, number => number);
        }

        public static decimal Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");
            decimal sum = 0;
            foreach (var element in source)
            {
                sum += selector(element);
            }

            return sum;
        }

        public static decimal? Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, decimal?> selector)
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(selector, "selector");
            decimal? sum = 0;
            foreach (var element in source)
            {
                sum += selector(element).GetValueOrDefault();
            }
            return sum;
        }
        #endregion
    }
}