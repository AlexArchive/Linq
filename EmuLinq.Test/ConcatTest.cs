using System;
using System.Collections.Generic;
using EmuLinq.Test.Support;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class ConcatTest
    {
        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().Concat(new ThrowingEnumerable());
        }

        [Test]
        public void ConactEnumerables()
        {
            // arrange
            var first = new[] { 1, 2, 3 };
            var second = new[] { 4, 5, 6 };

            // act
            var combined = first.Concat(second);

            // assert
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5, 6 }, combined);
        }

        [Test]
        public void NullFirstThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> first = null;
            IEnumerable<int> second = new[] { 1 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Concat(second));
        }

        [Test]
        public void NullSecondThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> first = new[] { 1 };
            IEnumerable<int> second = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Concat(second));
        }
    }
}