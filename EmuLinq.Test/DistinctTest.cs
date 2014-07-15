using EmuLinq.Test.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class DistinctTest
    {
        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().Distinct();
        }

        [Test]
        public void NullSourceNoComparer()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Distinct());
        }

        [Test]
        public void NullSourceWithComparer()
        {
            // arrange
            IEnumerable<int> source = null;
           
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.Distinct(EqualityComparer<int>.Default));
        }

        [Test]
        public void NoComparerUsesDefault()
        {
            // arrange
            var source = new[] { 1, 2, 3, 1, 2, 3 };

            // act
            var result = source.Distinct();

            // assert
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, result);
        }

        [Test]
        public void NullComparerUsesDefault()
        {
            // arrange
            var source = new[] { 1, 2, 3, 1, 2, 3 };

            // act
            var result = source.Distinct(null);

            // assert
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, result);
        }

        [Test]
        public void DistinctStringsWithCaseInsensitiveComparer()
        {
            // arrange
            string[] source = { "abc", "ABC" };

            // act
            var result = source.Distinct(StringComparer.OrdinalIgnoreCase);

            // assert
            CollectionAssert.AreEquivalent(new[] { "abc" }, result);
        }
    }
}