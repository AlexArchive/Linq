using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class LastOrDefaultTest
    {
        [Test]
        public void NullSourceWithoutPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault());
        }

        [Test]
        public void EmptySequenceWithoutPredicate()
        {
            var source = new int[] { };

            Assert.That(source.LastOrDefault(), Is.EqualTo(0));
        }

        [Test]
        public void SingleElementSequenceWithoutPredicate()
        {
            var source = new[] { 3 };
            Assert.That(source.LastOrDefault(), Is.EqualTo(3));
        }

        [Test]
        public void MultipleElementSequenceWithoutPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.LastOrDefault(), Is.EqualTo(3));
        }

        [Test]
        public void NullSourceWithPredicate()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(x => true));
        }

        [Test]
        public void EmptySequenceWithPredicate()
        {
            var source = new int[] { };
            Assert.That(source.LastOrDefault(x => true), Is.EqualTo(0));
        }

        [Test]
        public void SingleElementSequenceWithMatchingPredicate()
        {
            var source = new[] { 3 };
            Assert.That(source.LastOrDefault(x => x == 3), Is.EqualTo(3));
        }

        [Test]
        public void SingleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 3 };

            Assert.That(source.LastOrDefault(x=> x ==1), Is.EqualTo(0));
        }

        [Test]
        public void MultipleElementSequenceWithSinglePredicateMatch()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.LastOrDefault(x => x == 2), Is.EqualTo(2));
        }

        [Test]
        public void MultipleElementSequenceWithMultiplePredicateMatch()
        {
            var source = new[] { 1, 2, 3, 2 };
            Assert.That(source.LastOrDefault(x => x == 2), Is.EqualTo(2));
        }

        [Test]
        public void MultipleElementSequenceWithNonMatchingPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.LastOrDefault(x => false), Is.EqualTo(0));
        }

        [Test]
        public void NullPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.LastOrDefault(null));
        }
    }
}