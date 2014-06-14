using System;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class RepeatTest
    {
        [Test]
        public void RepeatInteger()
        {
            // act
            var result = Enumerable.Repeat(10, 2);

            // assert
            CollectionAssert.AreEquivalent(new[] { 10, 10 }, result);
        }

        [Test]
        public void RepeatString()
        {
            // act
            var result = Enumerable.Repeat("allo", 2);

            // assert
            CollectionAssert.AreEquivalent(new[] { "allo", "allo" }, result);
        }

        [Test]
        public void RepeatZeroTimes()
        {
            CollectionAssert.IsEmpty(Enumerable.Repeat("", 0));
        }

        [Test]
        public void ElementCanBeNull()
        {
            // act
            var result = Enumerable.Repeat<string>(null, 2);

            // assert
            CollectionAssert.AreEquivalent(new string[] { null, null }, result);
        }

        [Test]
        public void NegativeCountThrowsArgumentOutOfRangeException()
        {
            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Repeat("", -1));
        }
    }
}