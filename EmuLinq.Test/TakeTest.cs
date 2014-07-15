using EmuLinq.Test.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class TakeTest
    {
        [Test]
        public void Execution_IsDeferred()
        {
            new ThrowingEnumerable().Take(1);
        }

        [Test]
        public void NullSource_Throws()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Take(10));
        }

        [Test]
        public void Zero_ReturnsEmptySequence()
        {
            var sequence = Enumerable.Range(0, 100);
            var actual = sequence.Take(0);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void NegativeCount_ReturnsEmptySequence()
        {
            var sequence = Enumerable.Range(0, 100);
            var actual = sequence.Take(-100);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void OnlyEnumerateTheGivenNumberOfElements()
        {
            var sequence = new[] { 1, 2, 0 };
            var query = sequence.Select(x => 10 / x);
            var actual = query.Take(2);
            CollectionAssert.AreEquivalent(new[] { 10, 5 }, actual);
        }

        [Test]
        public void CountShorterThanSource()
        {
            var sequence = Enumerable.Range(1, 10);
            var actual = sequence.Take(5);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5 }, actual);
        }

        [Test]
        public void CountEqualToSource()
        {
            var sequence = Enumerable.Range(1, 10);
            var actual = sequence.Take(10);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, actual);
        }

        [Test]
        public void CountGreaterThanSource()
        {
            var sequence = Enumerable.Range(1, 10);
            var actual = sequence.Take(15);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, actual);
        }
    }
}