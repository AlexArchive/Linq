using System;
using System.Collections.Generic;
using EmuLinq.Test.Support;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class UnionTest
    {
        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().Union(new ThrowingEnumerable());
        }

        [Test]
        public void UnionWithoutComparer()
        {
            // arrange
            var first = new[] { "a", "b", "c" };
            var second = new[] { "b", "c", "d", "e", "f" };

            // act
            var result = first.Union(second);

            // assert
            CollectionAssert.AreEquivalent(new[] { "a", "b", "c", "d", "e", "f" }, result);
        }

        [Test]
        public void UnionWithNullComparer()
        {
            // arrange
            var first = new[] { "a", "b", "c" };
            var second = new[] { "b", "c", "d", "e", "f" };

            // act
            var result = first.Union(second, null);

            // assert
            CollectionAssert.AreEquivalent(new[] { "a", "b", "c", "d", "e", "f" }, result);
        }

        [Test]
        public void UnionWithCaseInsensitiveComparer()
        {
            // arrange
            var first = new[] { "a", "b", "c" };
            var second = new[] { "B", "C", "d", "e", "f" };

            // act
            var result = first.Union(second, StringComparer.OrdinalIgnoreCase);

            // assert
            CollectionAssert.AreEquivalent(new[] { "a", "b", "c", "d", "e", "f" }, result);
        }

        [Test]
        public void UnionWithEmptyFirstSequence()
        {
            // arrange
            var first = new string[] { };
            var second = new[] { "a", "a", "b", "c" };
            
            // act
            var result = first.Union(second);

            // assert
            CollectionAssert.AreEquivalent(new[] { "a", "b", "c" }, result);
        }

        [Test]
        public void UnionWithEmptySecondSequence()
        {
            // arrange
            var first = new[] { "a", "a", "b", "c" };
            var second = new string[] { };

            // act
            var result = first.Union(second);

            // assert
            CollectionAssert.AreEquivalent(new[] { "a", "b", "c" }, result);
        }

        [Test]
        public void UnionWithTwoEmptySequences()
        {
            // arrange
            string[] first = { };
            string[] second = { };

            // act
            // assert
            CollectionAssert.IsEmpty(first.Union(second));
        }

        [Test]
        public void NullFirstWithoutComparer()
        {
            // arrange
            IEnumerable<string> first = null;
            var second = new string[] { };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Union(second));
        }

        [Test]
        public void NullSecondWithoutComparer()
        {
            // arrange
            var first = new string[] { };
            IEnumerable<string> second = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Union(second));
        }

        [Test]
        public void NullFirstWithComparer()
        {
            // arrange
            IEnumerable<string> first = null;
            var second = new string[] { };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Union(second, StringComparer.Ordinal));
        }

        [Test]
        public void NullSecondWithComparer()
        {
            // arrange
            var first = new string[] { };
            IEnumerable<string> second = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => first.Union(second, StringComparer.Ordinal));
        }
    }
}