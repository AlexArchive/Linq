using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class LastTest
    {
        [Test]
        public void NullSourceWithoutPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Last());
        }

        [Test]
        public void EmptySequenceWithoutPredicate()
        {
            var source = new int[] { };
            Assert.Throws<InvalidOperationException>(() => source.Last());
        }

        [Test]
        public void SingleElementSequenceWithoutPredicate()
        {
            var source = new[] { 3 };
            Assert.That(source.Last(), Is.EqualTo(3));
        }

        [Test]
        public void MultipleElementSequenceWithoutPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.Last(), Is.EqualTo(3));
        }

        [Test]
        public void NullSourceWithPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Last(x => true));
        }

        [Test]
        public void EmptySequenceWithPredicate()
        {
            var source = new int[] { };
            Assert.Throws<InvalidOperationException>(() => source.Last(x => true));
        }

        [Test]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            var source = new[] { 3 };
            Assert.That(source.Last(x => x == 3), Is.EqualTo(3));
        }

        [Test]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 3 };
            Assert.Throws<InvalidOperationException>(() => source.Last(x => x == 1));
        }

        [Test]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.Last(x => x == 2), Is.EqualTo(2));
        }

        [Test]
        public void MultipleElementSequenceWithMultiplePredicateMatch()
        {
            var source = new[] { 1, 2, 3, 2};
            Assert.That(source.Last(x => x == 2), Is.EqualTo(2));
        }

        [Test]
        public void MultipleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<InvalidOperationException>(() => source.Last(x => false));
        }

        [Test]
        public void NullPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.Last(null));
        }
    }
}
