using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class FirstOrDefaultTest
    {
        [Test]
        public void EmptySequenceOfValueTypeWithoutPredicate()
        {
            // arrange
            var source = new int[] { };

            // act
            // assert
            Assert.That(source.FirstOrDefault(), Is.EqualTo(0));
        }

        [Test]
        public void EmptySequenceOfReferenceTypeWithoutPredicate()
        {
            // arrange
            var source = new string[] { };

            // act
            // assert
            Assert.That(source.FirstOrDefault(), Is.EqualTo(null));
        }

        [Test]
        public void SingleElementSequenceWithoutPredicate()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.FirstOrDefault(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithoutPredicate()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.That(source.FirstOrDefault(), Is.EqualTo(1));
        }

        [Test]
        public void NullSourceWithoutPredicate()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault());
        }

        [Test]
        public void EmptySequenceWithPredicate()
        {
            // arrange
            var source = new int[] { };

            // act
            // assert
            Assert.That(source.FirstOrDefault(x=>true), Is.EqualTo(0));
        }

        [Test]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.FirstOrDefault(n => n % 2 != 0), Is.EqualTo(1));
        }

        [Test]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            // arrange
            var source = new[] { 2 };

            // act
            // assert

            Assert.That(source.FirstOrDefault(n => n % 2 != 0), Is.EqualTo(0));
        }

        [Test]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.That(source.FirstOrDefault(n => n % 2 != 0), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.That(source.FirstOrDefault(n => n % 2 != 0), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithNonMatchingPreicate()
        {
            // arrange
            var source = new[] { 0, 2, 4 };

            // act
            // assert
            Assert.That(source.FirstOrDefault(n => n % 2 != 0), Is.EqualTo(0));
        }

        [Test]
        public void NullSourceWithPredicate()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(x => true));
        }

        [Test]
        public void NullPredicate()
        {
            // arrange
            var source = new[] { 1, 2, 3 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.FirstOrDefault(null));
        }
    }
}