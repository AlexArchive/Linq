using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class WhereTest
    {
        [Test]
        public void Filtering()
        {
            // arrange
            var source = new[] { 5, 10, 20 };

            // act
            var result = source.Where(n => n < 20);

            // assert
            CollectionAssert.AreEquivalent(new[] { 5, 10 }, result);
        }

        [Test]
        public void NullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Where(x => true));
        }

        [Test]
        public void NullPredicateThrowsArgumentNullException()
        {
            // arrange
            Func<int, bool> predicate = null;
            var source = new[] { 5, 10, 20 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void EmptySource()
        {
            // arrange
            var source = new int[0];
            
            // act
            var result = source.Where(x => x == 1);

            // assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void WithIndexFiltering()
        {
            // arrange 
            var source = new[] { 5, 10, 20 };

            // act
            var result = source.Where((n, i) => i % 2 == 0);

            // assert
            CollectionAssert.AreEquivalent(new[] { 5, 20 }, result);
        }

        [Test]
        public void WithIndexNullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Where((x, i) => true));
        }

        [Test]
        public void WithIndexNullPredicateThrowsArgumentNullException()
        {
            // arrange
            Func<int, int, bool> predicate = null;
            var source = new[] { 5, 10, 20 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Test]
        public void WithIndexEmptySource()
        {
            // arrange
            var source = new int[0];

            // act
            var result = source.Where((x, i) => x == 1);

            // assert
            CollectionAssert.IsEmpty(result);
        }
    }
}