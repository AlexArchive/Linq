using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SelectTest
    {
        [Test]
        public void Projection()
        {
            // arrange
            var source = new[] { 5, 10, 20 };

            // act
            var result = source.Select(x => x + x);

            // assert
            CollectionAssert.AreEquivalent(new[] { 10, 20, 40 }, result);
        }

        [Test]
        public void ProjectionToDifferentType()
        {
            // arrange
            var source = new[] { 5, 10, 20 };

            // act
            var result = source.Select(x => x.ToString());

            // assert
            CollectionAssert.AreEquivalent(new[] { "5", "10", "20" }, result);
        }

        [Test]
        public void NullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Select(x => x));
        }

        [Test]
        public void NullSelectorThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { 5, 10, 20 };
            Func<int, int> selector = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Select(selector));
        }

        [Test]
        public void EmptySource()
        {
            // arrange
            var source = new int[0];

            // act
            var result = source.Select(x => x);
            // assert

            CollectionAssert.AreEquivalent(result, source);
        }

        [Test]
        public void WithIndexProjection()
        {
            // arrange
            var source = new[] { 5, 10, 20 };

            // act
            var result = source.Select((x, i) => x * i);

            // assert
            CollectionAssert.AreEquivalent(new[] { 0, 10, 40 }, result);
        }

        [Test]
        public void WithIndexProjectionToDifferentType()
        {
            // arrange
            var source = new[] { 5, 10, 20 };

            // act
            var result = source.Select((x, i) => x.ToString() + i);

            // assert
            CollectionAssert.AreEquivalent(new[] { "50", "101", "202" }, result);
        }

        [Test]
        public void WithIndexNullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Select((x, i) => x));
        }

        [Test]
        public void WithIndexNullSelectorThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { 5, 10, 20 };
            Func<int, int, int> selector = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Select(selector));
        }

        [Test]
        public void WithIndexEmptySource()
        {
            // arrange
            var source = new int[0];

            // act
            var result = source.Select((x, i) => x * i);
            // assert

            CollectionAssert.AreEquivalent(result, source);
        }
    }
}