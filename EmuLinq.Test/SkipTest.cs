using System;
using System.Collections.Generic;
using EmuLinq.Test.Support;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SkipTest
    {
        [Test]
        public void NullSource_ThrowsException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Skip(1));
        }

        [Test]
        public void CountEqualToZero_ReturnsAll()
        {
            var source = Enumerable.Range(1, 5);
            var actual = source.Skip(0);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5 }, actual);
        }

        [Test]
        public void CountLessThanZero_ReturnsAll()
        {
            var source = Enumerable.Range(1, 5);
            var actual = source.Skip(-5);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5 }, actual);
        }

        [Test]
        public void CountGreaterThanSource_ReturnsEmpty()
        {
            var source = Enumerable.Range(1, 5);
            var actual = source.Skip(10);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void CountEqualToSource_ReturnsEmpty()
        {
            var source = Enumerable.Range(1, 5);
            var actual = source.Skip(5);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void CountLessThanSource_ReturnsExpected()
        {
            var source = Enumerable.Range(1, 10);
            var actual = source.Skip(5);
            CollectionAssert.AreEquivalent(new[] { 6, 7, 8, 9, 10 }, actual);
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().Skip(10);
        }
    }
}