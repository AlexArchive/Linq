using EmuLinq.Test.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class TakeWhileTest
    {
        [Test]
        public void NullSourceNoIndex()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.TakeWhile(number => true));
        }

        [Test]
        public void NullSourceUsingIndex()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.TakeWhile((number, index) => true));
        }

        [Test]
        public void NullPredicateNoIndex()
        {
            var source = Enumerable.Range(0, 1);
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.TakeWhile(predicate));
        }

        [Test]
        public void NullPredicateUsingIndex()
        {
            var source = Enumerable.Range(0, 1);
            Func<int, int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.TakeWhile(predicate));
        }

        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().TakeWhile(number => true);
            new ThrowingEnumerable().TakeWhile((number, index) => true);
        }

        [Test]
        public void PredicateMatchingSomeElements()
        {
            var source = Enumerable.Range(1, 5);
            var actual = source.TakeWhile(number => number <= 2);
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, actual);
        }

        [Test]
        public void PredicateMatchingSomeElementsUsingIndex()
        {
            var source = Enumerable.Range(1, 5);
            var actual = source.TakeWhile((number, index) => index <= 2);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, actual);
        }

        [Test]
        public void PredicateMatchingNoElements()
        {
            var source = Enumerable.Range(0, 10);
            var actual = source.TakeWhile(number => number > 10);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void PredicateMatchingNoElementsUsingIndex()
        {
            var source = Enumerable.Range(0, 10);
            var actual = source.TakeWhile((number, index) => number > 10);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void PredicateMatchingAllElements()
        {
            var source = Enumerable.Range(0, 10);
            var actual = source.TakeWhile(number => number <= 10);
            Assert.AreNotSame(source, actual);
            CollectionAssert.AreEquivalent(source, actual);
        }

        [Test]
        public void PredicateMatchingAllElementsUsingIndex()
        {
            var source = Enumerable.Range(0, 10);
            var actual = source.TakeWhile((number, index) => number <= 10);
            Assert.AreNotSame(source, actual);
            CollectionAssert.AreEquivalent(source, actual);
        }
    }
}