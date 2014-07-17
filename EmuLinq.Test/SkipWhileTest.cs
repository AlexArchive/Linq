using System;
using System.Collections.Generic;
using EmuLinq.Test.Support;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SkipWhileTest
    {
        [Test]
        public void NullSource_WithoutIndex_Throws()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.SkipWhile(number => true));
        }

        [Test]
        public void NullSource_WithIndex_Throws()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.SkipWhile((number, index) => true));
        }

        [Test]
        public void NullPredicate_WithoutIndex_Throws()
        {
            var source = Enumerable.Range(0, 1);
            Func<int, bool> prediate = null;
            Assert.Throws<ArgumentNullException>(() => source.SkipWhile(prediate));
        }

        [Test]
        public void NullPredicate_WithIndex_Throws()
        {
            var source = Enumerable.Range(0, 1);
            Func<int, int, bool> prediate = null;
            Assert.Throws<ArgumentNullException>(() => source.SkipWhile(prediate));
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().SkipWhile(number => true);
            new ThrowingEnumerable().SkipWhile((number, index) => true);

        }

        [Test]
        public void PredicateMachingSomeElements_WithoutIndex_ReturnsExpected()
        {
            var source = Enumerable.Range(1, 10);
            var actual = source.SkipWhile(number => number <= 5);
            CollectionAssert.AreEquivalent(new[] { 6, 7, 8, 9, 10 }, actual);
        }

        [Test]
        public void PredicateMachingSomeElements_WithIndex_ReturnsExpected()
        {
            var source = Enumerable.Range(1, 10);
            var actual = source.SkipWhile((number, index) => index <= 5);
            CollectionAssert.AreEquivalent(new[] { 7, 8, 9, 10 }, actual);
        }

        [Test]
        public void PredicateMachingAllElements_WithoutIndex_ReturnsNone()
        {
            var source = Enumerable.Range(1, 10);
            var actual = source.SkipWhile(number => true);
            CollectionAssert.AreEquivalent(Enumerable.Empty<int>(), actual);
        }

        [Test]
        public void PredicateMachingAllElements_WithIndex_ReturnsNone()
        {
            var source = Enumerable.Range(1, 10);
            var actual = source.SkipWhile((number, index) => index < 100);
            CollectionAssert.AreEquivalent(Enumerable.Empty<int>(), actual);
        }

        [Test]
        public void PredicateMatchingNoElements_WithoutIndex_ReturnsAll()
        {
            var source = Enumerable.Range(1, 10);
            var actual = source.SkipWhile(number => false);
            CollectionAssert.AreEquivalent(Enumerable.Range(1, 10), actual);
        }


        [Test]
        public void PredicateMatchingNoElements_WithIndex_ReturnsAll()
        {
            var source = Enumerable.Range(1, 10);
            var actual = source.SkipWhile((number, index) => false);
            CollectionAssert.AreEquivalent(Enumerable.Range(1, 10), actual);
        }
    }
}