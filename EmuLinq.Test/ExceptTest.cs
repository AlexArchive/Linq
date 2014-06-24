using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class ExceptTest
    {
        [Test]
        public void ExceptWithoutComparer()
        {
            // arrange
            var first = new[] { "a", "b", "c", "d", "e" };
            var second = new[] { "a", "b", "c" };

            // act
            var result = first.Except(second);

            // assert
            CollectionAssert.AreEquivalent(new[] { "d", "e" }, result);
        }

        [Test]
        public void ExceptWithNullComparer()
        {
            // arrange
            var first = new[] { "a", "b", "c", "d", "e" };
            var second = new[] { "a", "b", "c" };

            // act
            var result = first.Except(second, null);

            // assert
            CollectionAssert.AreEquivalent(new[] { "d", "e" }, result);
        }

        [Test]
        public void ExceptWithCaseInsensitiveComparer()
        {
            // arrange
            var first = new[] { "a", "B", "c", "d", "e" };
            var second = new[] { "a", "b", "C" };

            // act
            var result = first.Except(second, StringComparer.OrdinalIgnoreCase);

            // assert
            CollectionAssert.AreEquivalent(new[] { "d", "e" }, result);
        }

        [Test]
        public void NullFirstWithoutComparer()
        {
            // arrange
            IEnumerable<string> first = null;
            var second = new string[] { };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Except(second));
        }

        [Test]
        public void NullSecondWithoutComparer()
        {
            // arrange
            var first = new string[] { };
            IEnumerable<string> second = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Except(second));
        }

        [Test]
        public void NullFirstWithComparer()
        {
            // arrange
            IEnumerable<string> first = null;
            var second = new string[] { };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Except(second, StringComparer.Ordinal));
        }

        [Test]
        public void NullSecondWithComparer()
        {
            // arrange
            var first = new string[] { };
            IEnumerable<string> second = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Except(second, StringComparer.Ordinal));
        }

    }
}