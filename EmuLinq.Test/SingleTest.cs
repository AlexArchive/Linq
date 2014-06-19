using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SingleTest
    {
        [Test]
        public void NullSourceWithoutPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Single());
        }

        [Test]
        public void EmptySequenceWithoutPredicate()
        {
            var source = new int[] { };
            Assert.Throws<InvalidOperationException>(() => source.Single());
        }

        [Test]
        public void SingleElementSequenceWithoutPredicate()
        {
            var source = new[] { 1 };
            Assert.That(source.Single(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithoutPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<InvalidOperationException>(() => source.Single());
        }

        [Test]
        public void NullSourceWithPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Single(x => true));
        }

        [Test]
        public void EmptySequenceWithPredicate()
        {
            var source = new int[] { };
            Assert.Throws<InvalidOperationException>(() => source.Single(x => true));
        }

        [Test]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            var source = new[] { 1 };
            Assert.That(source.Single(x => x == 1), Is.EqualTo(1));
        }

        [Test]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 1 };
            Assert.Throws<InvalidOperationException>(() => source.Single(x => x == 2));
        }

        [Test]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<InvalidOperationException>(() => source.Single(x => x == 1));
        }

        [Test]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            var source = new[] { 1, 2, 3, 1 };
            Assert.Throws<InvalidOperationException>(() => source.Single(x => x == 1));
        }

        [Test]
        public void MultipleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<InvalidOperationException>(() => source.Single(x => x == 10));
        }

        [Test]
        public void NullPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.Single(null));
        }
    }
}