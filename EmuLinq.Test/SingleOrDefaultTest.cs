using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SingleOrDefaultTest
    {
        [Test]
        public void NullSourceWithoutPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault());
        }

        [Test]
        public void EmptySequenceWithoutPredicate()
        {
            var source = new int[] { };
            Assert.That(source.SingleOrDefault(), Is.EqualTo(0));
        }

        [Test]
        public void SingleElementSequenceWithoutPredicate()
        {
            var source = new[] { 1 };
            Assert.That(source.SingleOrDefault(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleElementSequenceWithoutPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.SingleOrDefault(), Is.EqualTo(0));
        }

        [Test]
        public void NullSourceWithPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(x => true));
        }

        [Test]
        public void EmptySequenceWithPredicate()
        {
            var source = new int[] { };
            Assert.That(source.SingleOrDefault(x => true), Is.EqualTo(0));
        }

        [Test]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            var source = new[] { 1 };
            Assert.That(source.SingleOrDefault(x => x == 1), Is.EqualTo(1));
        }

        [Test]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 1 };
            Assert.That(source.SingleOrDefault(x => x == 2), Is.EqualTo(0));
        }

        [Test]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.SingleOrDefault(x => x==1), Is.EqualTo(0));
        }

        [Test]
        public void MultipleElementSequenceWithMultiplePredicateMatches()
        {
            var source = new[] { 1, 2, 3, 1 };
            Assert.That(source.SingleOrDefault(x => x == 1), Is.EqualTo(0));
        }

        [Test]
        public void MultipleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.SingleOrDefault(x => x == 10), Is.EqualTo(0));
        }

        [Test]
        public void NullPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.SingleOrDefault(null));
        }
    }
}