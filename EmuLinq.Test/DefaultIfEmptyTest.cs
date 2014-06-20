using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class DefaultIfEmptyTest
    {
        [Test]
        public void NullSource()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.DefaultIfEmpty());
        }

        [Test]
        public void EmptySequence()
        {
            var source = new string[] { };
            CollectionAssert.AreEquivalent(new string[] { null }, source.DefaultIfEmpty());
        }

        [Test]
        public void NonEmptySequence()
        {
            var source = new[] { 1, 2, 3 };
            CollectionAssert.AreEquivalent(source, source.DefaultIfEmpty());
        }
        
        [Test]
        public void NullSourceWithSpecifiedDefaultValue()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.DefaultIfEmpty(5));
        }
        
        [Test]
        public void EmptySequenceWithDefaultValuet()
        {
            var source = new string[] { };
            CollectionAssert.AreEquivalent(new[] { "England" }, source.DefaultIfEmpty("England"));
        }

        [Test]
        public void NonEmptySequenceWithDefaultValue()
        {
            var source = new[] { 1, 2, 3 };
            CollectionAssert.AreEquivalent(source, source.DefaultIfEmpty(4));
        }
    }
}