using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class FirstTest
    {
        [Test]
        public void EmptySequenceWithoutPredicate()
        {
            // arrange
            var source = new int[] { };

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => source.First());
        }

        [Test]
        public void SingleElementSequenceWithoutPredicate()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.First(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithoutPredicate()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.That(source.First(), Is.EqualTo(1));
        }

        [Test]
        public void NullSourceWithoutPredicate()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.First());
        }

        [Test]
        public void EmptySequenceWithPredicate()
        {
            // arrange
            var source = new int[] { };

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => source.First(x => true));
        }

        [Test]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.First(n => n % 2 != 0), Is.EqualTo(1));
        }

        [Test]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            // arrange
            var source = new[] { 2 };

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => source.First(n => n % 2 != 0));
        }

        [Test]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.First(n => n % 2 != 0), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.That(source.First(n => n % 2 != 0), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithNonMatchingPreicate()
        {
            // arrange
            var source = new[] { 0, 2, 4 };

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => source.First(n => n % 2 != 0));
        }

        [Test]
        public void NullSourceWithPredicate()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.First(x => true));
        }

        [Test]
        public void NullPredicate()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.First(null));
        }
    }
}