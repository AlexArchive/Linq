using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class CountTest
    {
        [Test]
        public void CountIsAccurate()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            var count = source.Count();

            // assert
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void EmptyCountIsAccurate()
        {
            // arrange
            var source = new int[0];

            // act
            var count = source.Count();

            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void PredicatedCountIsAccurate()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            var count = source.Count(x => x != 2);

            // assert
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void PredicatedEmptyCountIsAccurate()
        {
            // arrange
            var source = new int[0];

            // act
            var count = source.Count(x => x != 2);

            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void NullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Count());
        }

        [Test]
        public void PredicatedNullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Count(x => x != 2));
        }

        [Test]
        public void NullPredicateThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Count(null));
        }
    }
}