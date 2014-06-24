using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class AnyTest
    {
        [Test]
        public void EmptySourceReturnsFalse()
        {
            // arrange
            var source = new int[0];

            // act
            // assert
            Assert.That(source.Any(), Is.False);
        }

        [Test]
        public void NonEmptySourceReturnsTrue()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.Any(), Is.True);
        }

        [Test]
        public void NullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Any());
        }

        [Test]
        public void EmptySourceWithPredicateReturnsFalse()
        {
            // arrange
            var source = new int[0];

            // act
            // assert
            Assert.That(source.Any(x => x == 1), Is.False);
        }

        [Test]
        public void NonEmptySourceWithMatchingPredicateReturnsTrue()
        {
            // arrange
            var source = new[] { 1, 2};

            // act
            // assert
            Assert.That(source.Any(x => x == 2), Is.True);
        }
        [Test]
        public void NonEmptySourceWithNonMatchingPredicateReturnsFalse()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.Any(x => x == 3), Is.False);
        }

        [Test]
        public void NullSourceWithPredicateThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Any(x => x == 1));
        }

        [Test]
        public void NullPredicateThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Any(null));
        }

    }
}