using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class AggregateTest
    {
        [Test]
        public void NullSource()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Aggregate((a, b) => a));
        }

        [Test]
        public void NullFunc()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Aggregate(null));
        }

        [Test]
        public void UnseededAggregation()
        {
            // arrange
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // act
            var result = source.Aggregate((sum, number) => sum + number);

            // assert
            Assert.That(result, Is.EqualTo(55));
        }

        [Test]
        public void UnseededAggregationWithEmptySequence()
        {
            // arrange
            var source = new int[] { };

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => source.Aggregate((sum, number) => sum + number));
        }

        [Test]
        public void UnseededAggregationUsesFirstElementOfSequenceAsSeed()
        {
            // arrange
            int[] source = { 5, 3, 2 };

            // act
            // assert
            Assert.AreEqual(30, source.Aggregate((acc, value) => acc * value));
        }

        [Test]
        public void NullSourceSeeded()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Aggregate(0, (a, b) => a));
        }

        [Test]
        public void NullFuncSeeded()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Aggregate(0, null));
        }

        [Test]
        public void SeededAggregation()
        {
            // arrange
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // act
            var result = source.Aggregate(10, (sum, number) => sum + number);

            // assert
            Assert.That(result, Is.EqualTo(65));
        }

        [Test]
        public void NullSourceSeededWithResultSelector()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Aggregate(0, (a, b) => a, a => a));
        }

        [Test]
        public void NullFuncSeededWithResultSelector()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Aggregate(0, null, i => i));
        }

        [Test]
        public void NullResultSelector()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Aggregate(0, (a, b) => a, (Func<int, int>)null));
        }

        [Test]
        public void SeededAggregationWithResultSelector()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            var result = source.Aggregate(
                new { Sum = 0, Count = 0 },
                (anonObj, number) => new { Sum = anonObj.Sum + number, Count = anonObj.Count + 1 },
                anonObj => anonObj.Sum / anonObj.Count);

            // assert
            Assert.That(result, Is.EqualTo(2));
        }
    }
}