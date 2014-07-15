using System;
using System.Collections.Generic;
using EmuLinq.Test.Support;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class IntersectTest
    {
        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().Intersect(new ThrowingEnumerable());
        }

        [Test]
        public void IntersectWithoutComparer()
        {
            var first = new[] { "a", "b", "c", "d"};
            var second = new[] { "a", "b", "c"};

            var result = first.Intersect(second);

            CollectionAssert.AreEquivalent(new[] { "a", "b", "c" }, result);
        }

        [Test]
        public void IntersectWithNullComparer()
        {
            var first = new[] { "a", "b", "c", "d" };
            var second = new[] { "a", "b", "c" };

            var result = first.Intersect(second, null);

            CollectionAssert.AreEquivalent(new[] { "a", "b", "c" }, result);
        }

        [Test]
        public void IntersectWithCaseInsensitiveComparer()
        {
            var first = new[] { "a", "B", "c", "d" };
            var second = new[] { "A", "b", "c" };

            var result = first.Intersect(second, StringComparer.OrdinalIgnoreCase);

            CollectionAssert.AreEquivalent(new[] { "a", "B", "c" }, result);
        }

        [Test]
        public void NullFirstWithoutComparer()
        {
            // arrange
            IEnumerable<string> first = null;
            var second = new string[] { };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second));
        }

        [Test]
        public void NullSecondWithoutComparer()
        {
            // arrange
            var first = new string[] { };
            IEnumerable<string> second = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second));
        }

        [Test]
        public void NullFirstWithComparer()
        {
            // arrange
            IEnumerable<string> first = null;
            var second = new string[] { };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, StringComparer.Ordinal));
        }

        [Test]
        public void NullSecondWithComparer()
        {
            // arrange
            var first = new string[] { };
            IEnumerable<string> second = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second, StringComparer.Ordinal));
        }
    }
}