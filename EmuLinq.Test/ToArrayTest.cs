using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class ToArrayTest
    {
        [Test]
        public void SimpleSequence()
        {
            IEnumerable<int> source = Enumerable.Range(0, 12);
            int[] result = source.ToArray();
            CollectionAssert.AreEquivalent(source, result);
        }

        [Test]
        public void NullSource()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.ToArray());
        }
    }
}