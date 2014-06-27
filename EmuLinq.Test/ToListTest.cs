using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class ToListTest
    {
        [Test]
        public void SimpleSequence()
        {
            var source = Enumerable.Range(0, 100);
            var result = source.ToList();
            CollectionAssert.AreEquivalent(source, result);
        }

        [Test]
        public void NullSource()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() =>source.ToList());
        }
    }
}