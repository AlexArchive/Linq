using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class AllTest
    {
        [Test]
        public void PredicateMachingAllElementsReturnsTrue()
        {
            var source = new[] { "Alex", "Andrew", "Anders", "Andrea" };
            Assert.That(source.All(x => x.StartsWith("A")), Is.True);
        }

        [Test]
        public void PredicateMatchingNoElementsReturnsFalse()
        {
            var source = new[] { "Alex", "Andrew", "Anders", "Andrea" };
            Assert.That(source.All(x => x.StartsWith("B")), Is.False);
        }

        [Test]
        public void PredicateMatchingSomeElementsReturnsFalse()
        {
            var source = new[] { "Alex", "Andrew", "Anders", "Andrea", "Bob" };
            Assert.That(source.All(x => x.StartsWith("B")), Is.False);
        }

        [Test]
        public void EmptySourceReturnsTrue()
        {
            var source = new int[0];
            Assert.That(source.All(x => x == 10), Is.True);
        }

        [Test]
        public void NullPredicateThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { 1 };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.All(null));
        }

        [Test]
        public void NullSourceWithPredicateThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<int> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.All(x => x == 1));
        }
    }
}