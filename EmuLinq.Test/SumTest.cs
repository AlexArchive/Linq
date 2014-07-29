using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SumTest
    {
        #region Int32
        [Test]
        public void NullSource_Int32()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_Int32()
        {
            var source = Enumerable.Empty<int>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Int32()
        {
            var source = new[] { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_Int32()
        {
            var source = new[] { int.MaxValue, int.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void Underflow_Int32()
        {
            var source = new[] { int.MinValue, int.MinValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void NullSource_NullableInt32()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_NullableInt32()
        {
            var source = Enumerable.Empty<int?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SequenceOfNulls_NullableInt32()
        {
            int?[] source = { null, null };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableInt32()
        {
            int?[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SequenceContainingNulls_NullableInt32()
        {
            int?[] source = { null, 1, 2, null, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_NullableInt32()
        {
            int?[] source = { int.MaxValue, int.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void NullSource_Int32_WithSelector()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(number => number));
        }

        [Test]
        public void NullSelector_Int32()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_Int32_WithSelector()
        {
            var source = Enumerable.Empty<int>();
            var actual = source.Sum(number => number);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Int32_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(number => number.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void Overflow_Int32_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            Assert.Throws<OverflowException>(() => source.Sum(number => int.MaxValue));
        }

        [Test]
        public void NullSource_NullableInt32_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (int?)word.Length));
        }

        [Test]
        public void NullSelector_NullableInt32()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int?> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_NullableInt32_WithSelector()
        {
            var source = Enumerable.Empty<string>();
            var actual = source.Sum(word => word.Length);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SequenceOfNulls_NullableInt32_WithSelector()
        {
            string[] source = { null, null };
            var actual = source.Sum(word => (int?)null);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableInt32_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word => (int?)word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void SequenceContainingNulls_NullableInt32_WithSelector()
        {
            var source = new[] { "x", "null", "abc", "null", "de" };
            var actual = source.Sum(word => word == "null" ? null : (int?)word.Length);
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_NullableInt32_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            Assert.Throws<OverflowException>(() => source.Sum(word => (int?)int.MaxValue));
        }
        #endregion

        #region Int64
        [Test]
        public void NullSource_Int64()
        {
            IEnumerable<long> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_Int64()
        {
            var source = Enumerable.Empty<long>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Int64()
        {
            long[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_Int64()
        {
            long[] source = { long.MaxValue, long.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void Underflow_Int64()
        {
            var source = new[] { long.MinValue, long.MinValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void NullSource_NullableInt64()
        {
            IEnumerable<long> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_NullableInt64()
        {
            var source = Enumerable.Empty<long?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SequenceOfNulls_NullableInt64()
        {
            long?[] source = { null, null };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableInt64()
        {
            long?[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SequenceContainingNulls_NullableInt64()
        {
            long?[] source = { null, 1, 2, null, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_NullableInt64()
        {
            long?[] source = { long.MaxValue, long.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void NullSource_Int64_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => word.Length));
        }

        [Test]
        public void NullSelector_Int64()
        {
            var source = Enumerable.Empty<string>();
            Func<string, long> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_Int64_WithSelector()
        {
            var source = Enumerable.Empty<string>();
            var actual = source.Sum(word => (long)word.Length);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Int64_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(number => (long)number.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void Overflow_Int64_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            Assert.Throws<OverflowException>(() => source.Sum(number => long.MaxValue));
        }

        [Test]
        public void NullSource_NullableInt64_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (long?)word.Length));
        }

        [Test]
        public void NullSelector_Nullableint64()
        {
            var source = Enumerable.Empty<string>();
            Func<string, long?> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_NullableInt64_WithSelector()
        {
            var source = Enumerable.Empty<string>();
            var actual = source.Sum(word => (long?)word.Length);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SequenceOfNulls_NullableInt64_WithSelector()
        {
            string[] source = { null, null };
            var actual = source.Sum(word => (long?)null);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableInt64_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word => (long?)word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void SequenceContainingNulls_NullableInt64_WithSelector()
        {
            var source = new[] { "x", "null", "abc", "null", "de" };
            var actual = source.Sum(word => word == "null" ? null : (long?)word.Length);
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_NullableInt64_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            Assert.Throws<OverflowException>(() => source.Sum(word => (long?)long.MaxValue));
        }

        #endregion

        #region Double
        [Test]
        public void NullSource_Double()
        {
            IEnumerable<double> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_Double()
        {
            var source = Enumerable.Empty<double>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Double()
        {
            double[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SequenceContainingNaN_Double()
        {
            double[] source = { 1, 3, double.NaN, 2 };
            Assert.IsNaN(source.Sum());
        }

        [Test]
        public void Overflow_Double()
        {
            double[] source = { double.MaxValue, double.MaxValue };
            var actual = source.Sum();
            Assert.That(double.IsPositiveInfinity(actual));
        }

        [Test]
        public void Underflow_Double()
        {
            double[] source = { double.MinValue, double.MinValue };
            var actual = source.Sum();
            Assert.That(double.IsNegativeInfinity(actual));
        }

        [Test]
        public void NullSource_NullableDouble()
        {
            IEnumerable<double?> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_NullableDouble()
        {
            var source = Enumerable.Empty<double?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SequenceOfNulls_NullableDouble()
        {
            double?[] source = { null, null };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableDouble()
        {
            double?[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SequenceContainingNaN_NullableDouble()
        {
            double?[] source = { 1, 3, double.NaN, 2 };
            var actual = source.Sum();
            Assert.That(double.IsNaN(actual.Value));
        }
        [Test]
        public void SequenceContainingNull_NullableDouble()
        {
            double?[] source = { 1, 3, null, 2 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_NullableDouble()
        {
            double?[] source = { double.MaxValue, double.MaxValue };
            var actual = source.Sum();
            Assert.That(double.IsPositiveInfinity(actual.Value));
        }

        [Test]
        public void NullSource_Double_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (double)word.Length));
        }

        [Test]
        public void NullSelector_Double()
        {
            var source = Enumerable.Empty<string>();
            Func<string, double> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_Double_WithSelector()
        {
            var source = Enumerable.Empty<double>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Double_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word=> (double) word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void SequenceContainingNaN_Double_WithSelector()
        {
            string[] source = { "x", "abc", "de" };
            Assert.IsNaN(source.Sum(x => x.Length == 3 ? x.Length : double.NaN));
        }

        [Test]
        public void Overflow_Double_WithSelector()
        {
            string[] source = { "x", "y" };
            Assert.IsTrue(double.IsPositiveInfinity(source.Sum(x => double.MaxValue)));
        }

        [Test]
        public void NullSource_NullableDouble_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (double?)word.Length));
        }

        [Test]
        public void NullSelector_NullableDouble()
        {
            var source = Enumerable.Empty<string>();
            Func<string, double?> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_NullableDouble_WithSelector()
        {
            var source = Enumerable.Empty<double?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableDouble_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word => (double?)word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void SequenceContainingNaN_NullableDouble_WithSelector()
        {
            string[] source = { "x", "abc", "de" };
            Assert.IsNaN(source.Sum(x => x.Length == 3 ? x.Length : (double?) double.NaN));
        }

        [Test]
        public void SequenceContainingNulls_NullableDouble_WithSelector()
        {
            string[] source = { "x", "null", "abc", "null", "de" };
            Assert.AreEqual(6, source.Sum(x => x == "null" ? null : (double?)x.Length));
        }

        [Test]
        public void Overflow_NullableDouble_WithSelector()
        {
            double?[] source = { double.MaxValue, double.MaxValue };
            Assert.IsTrue(double.IsPositiveInfinity(source.Sum().Value));
        }
        #endregion

        #region Single
        [Test]
        public void NullSource_Single()
        {
            IEnumerable<float> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_Single()
        {
            var source = Enumerable.Empty<float>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Single()
        {
            float[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SequenceContainingNaN_Single()
        {
            float[] source = { 1, 3, float.NaN, 2 };
            Assert.IsNaN(source.Sum());
        }

        [Test]
        public void Overflow_Single()
        {
            float[] source = { float.MaxValue, float.MaxValue };
            var actual = source.Sum();
            Assert.That(float.IsPositiveInfinity(actual));
        }

        [Test]
        public void Underflow_Single()
        {
            float[] source = { float.MinValue, float.MinValue };
            var actual = source.Sum();
            Assert.That(float.IsNegativeInfinity(actual));
        }

        [Test]
        public void NullSource_NullableSingle()
        {
            IEnumerable<float?> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_NullableSingle()
        {
            var source = Enumerable.Empty<float?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SequenceOfNulls_NullableSingle()
        {
            float?[] source = { null, null };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableSingle()
        {
            float?[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SequenceContainingNaN_NullableSingle()
        {
            float?[] source = { 1, 3, float.NaN, 2 };
            var actual = source.Sum();
            Assert.That(float.IsNaN(actual.Value));
        }
        [Test]
        public void SequenceContainingNull_NullableSingle()
        {
            float?[] source = { 1, 3, null, 2 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_NullableSingle()
        {
            float?[] source = { float.MaxValue, float.MaxValue };
            var actual = source.Sum();
            Assert.That(float.IsPositiveInfinity(actual.Value));
        }

        [Test]
        public void NullSource_Single_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (float)word.Length));
        }

        [Test]
        public void NullSelector_Single()
        {
            var source = Enumerable.Empty<string>();
            Func<string, float> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_Single_WithSelector()
        {
            var source = Enumerable.Empty<float>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Single_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word => (float)word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void SequenceContainingNaN_Single_WithSelector()
        {
            string[] source = { "x", "abc", "de" };
            Assert.IsNaN(source.Sum(x => x.Length == 3 ? x.Length : float.NaN));
        }

        [Test]
        public void Overflow_Single_WithSelector()
        {
            string[] source = { "x", "y" };
            Assert.IsTrue(float.IsPositiveInfinity(source.Sum(x => float.MaxValue)));
        }

        [Test]
        public void NullSource_NullableSingle_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (float?)word.Length));
        }

        [Test]
        public void NullSelector_NullableSingle()
        {
            var source = Enumerable.Empty<string>();
            Func<string, float?> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_NullableSingle_WithSelector()
        {
            var source = Enumerable.Empty<float?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableSingle_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word => (float?)word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void SequenceContainingNaN_NullableSingle_WithSelector()
        {
            string[] source = { "x", "abc", "de" };
            Assert.IsNaN(source.Sum(x => x.Length == 3 ? x.Length : (float?)float.NaN));
        }

        [Test]
        public void SequenceContainingNulls_NullableSingle_WithSelector()
        {
            string[] source = { "x", "null", "abc", "null", "de" };
            Assert.AreEqual(6, source.Sum(x => x == "null" ? null : (float?)x.Length));
        }

        [Test]
        public void Overflow_NullableSingle_WithSelector()
        {
            float?[] source = { float.MaxValue, float.MaxValue };
            Assert.IsTrue(float.IsPositiveInfinity(source.Sum().Value));
        }
        #endregion

        #region Decimal
        [Test]
        public void NullSource_Decimal()
        {
            IEnumerable<decimal> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_Decimal()
        {
            var source = Enumerable.Empty<decimal>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Decimal()
        {
            decimal[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_Decimal()
        {
            decimal[] source = { decimal.MaxValue, decimal.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void Underflow_Decimal()
        {
            decimal[] source = { decimal.MinValue, decimal.MinValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void NullSource_NullableDecimal()
        {
            IEnumerable<decimal?> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum());
        }

        [Test]
        public void EmptySequence_NullableDecimal()
        {
            var source = Enumerable.Empty<decimal?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void SequenceOfNulls_NullableDecimal()
        {
            decimal?[] source = { null, null };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableDecimal()
        {
            decimal?[] source = { 1, 2, 3 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void SequenceContainingNull_NullableDecimal()
        {
            decimal?[] source = { 1, 3, null, 2 };
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void Overflow_NullableDecimal()
        {
            decimal?[] source = { decimal.MaxValue, decimal.MaxValue };
            Assert.Throws<OverflowException>(() => source.Sum());
        }

        [Test]
        public void NullSource_Decimal_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (decimal)word.Length));
        }

        [Test]
        public void NullSelector_Decimal()
        {
            var source = Enumerable.Empty<string>();
            Func<string, decimal> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_Decimal_WithSelector()
        {
            var source = Enumerable.Empty<decimal>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_Decimal_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word => (decimal)word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void Overflow_Decimal_WithSelector()
        {
            string[] source = { "x", "y" };
            Assert.Throws<OverflowException>(() => source.Sum(x => decimal.MaxValue));
        }

        [Test]
        public void NullSource_NullableDecimal_WithSelector()
        {
            IEnumerable<string> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(word => (decimal?)word.Length));
        }

        [Test]
        public void NullSelector_NullableDecimal()
        {
            var source = Enumerable.Empty<string>();
            Func<string, decimal?> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Sum(selector));
        }

        [Test]
        public void EmptySequence_NullableDecimal_WithSelector()
        {
            var source = Enumerable.Empty<decimal?>();
            var actual = source.Sum();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void Sum_NullableDecimal_WithSelector()
        {
            var source = new[] { "stack", "overflow" };
            var actual = source.Sum(word => (decimal?)word.Length);
            Assert.That(actual, Is.EqualTo(13));
        }

        [Test]
        public void SequenceContainingNulls_NullableDecimal_WithSelector()
        {
            string[] source = { "x", "null", "abc", "null", "de" };
            Assert.AreEqual(6, source.Sum(x => x == "null" ? null : (decimal?)x.Length));
        }

        [Test]
        public void Overflow_NullableDecimal_WithSelector()
        {
            string[] source = { "x", "y" };
            Assert.Throws<OverflowException>(() => source.Sum(x => (decimal?)decimal.MaxValue));
        }

        #endregion
    }
}