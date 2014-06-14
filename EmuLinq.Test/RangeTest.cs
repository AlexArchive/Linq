using System;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class RangeTest
    {
        [Test]
        public void Range()
        {
            // act
            var result = Enumerable.Range(1, 5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result);
        }

        [Test]
        public void NegativeCountThrowsArgumentOutOfRangeException()
        {
            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(0, -10));
        }

        [Test]
        public void CountTooLarge()
        {
            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(Int32.MaxValue, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(2, Int32.MaxValue));
        }

        [Test]
        public void EmptyRange()
        {
            // act
            var result = Enumerable.Range(100, 0);

            // assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void NegativeStart()
        {
            // act
            var result = Enumerable.Range(-5, 5);

            // assert
            CollectionAssert.AreEquivalent(new[] { -5, -4, -3, -2, -1 }, result);
        }


        [Test]
        public void LargeButValidCount()
        {
            // act
            // assert
            Enumerable.Range(Int32.MaxValue, 1);
            Enumerable.Range(1, Int32.MaxValue);
        }
    }
}