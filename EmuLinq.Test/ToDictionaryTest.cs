using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmuLinq.Test
{
    [TestFixture]
    public class ToDictionaryTest
    {
        [Test]
        public void NullSource_KeySelector()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(element => element));
        }

        [Test]
        public void NullSelector_KeySelector()
        {
            IEnumerable<int> source = Enumerable.Empty<int>();
            Func<int, int> selector = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(selector));
        }

        [Test]
        public void KeySelector()
        {
            var source = new[] { "stack", "exchange" };

            var actual = source.ToDictionary(element => element[0]);

            Assert.That(actual['s'], Is.EqualTo("stack"));
            Assert.That(actual['e'], Is.EqualTo("exchange"));
        }

        [Test]
        public void NullSource_KeySelectorWithComparer()
        {
            IEnumerable<string> source = null;

            Assert.Throws<ArgumentNullException>(() =>
                source.ToDictionary(element => element, StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void NullSelector_KeySelectorWithComparer()
        {
            IEnumerable<string> source = Enumerable.Empty<string>();

            Assert.Throws<ArgumentNullException>(() =>
                source.ToDictionary(null, StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void KeySelectorWithComparer()
        {
            var source = new[] { "stack", "exchange", "Stack" };

            Assert.Throws<ArgumentException>(() =>
                source.ToDictionary(element => element, StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void KeySelectorWithNullComparer()
        {
            var source = new[] { "stack", "exchange", "Stack" };
            IEqualityComparer<char> comparer = null;

            var actual = source.ToDictionary(element => element[0], comparer);

            Assert.That(actual['s'], Is.EqualTo("stack"));
            Assert.That(actual['S'], Is.EqualTo("Stack"));
            Assert.That(actual['e'], Is.EqualTo("exchange"));
        }

        [Test]
        public void NullSource_KeyAndElementSelector()
        {
            IEnumerable<int> source = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(element => element, element => element));
        }

        [Test]
        public void NullKeySelector_KeyAndElementSelector()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(keySelector, element => element));
        }

        [Test]
        public void NullElementSelector_KeyAndElementSelector()
        {
            var source = Enumerable.Empty<int>();
            Func<int, int> elementSelector = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(element => element, elementSelector));
        }

        [Test]
        public void KeyAndElementSelector()
        {
            var source = new[] { "stack", "exchange" };

            var actual = source.ToDictionary(element => element[0], element => element.Length);

            Assert.That(actual['s'], Is.EqualTo(5));
            Assert.That(actual['e'], Is.EqualTo(8));
        }

        [Test]
        public void NullSource_KeyAndElementSelectorWithComparer()
        {
            IEnumerable<string> source = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(element => element, element => element, StringComparer.OrdinalIgnoreCase));
        }
        
        [Test]
        public void NullKeySelector_KeyAndElementSelectorWithComparer()
        {
            IEnumerable<string> source = Enumerable.Empty<string>();
            Func<string, string> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(keySelector, element => element, StringComparer.OrdinalIgnoreCase));
        }
     
        [Test]
        public void NullElementSelector_KeyAndElementSelectorWithComparer()
        {
            IEnumerable<string> source = Enumerable.Empty<string>();
            Func<string, string> elementSelector = null;

            Assert.Throws<ArgumentNullException>(() => source.ToDictionary(element => element,elementSelector, StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void KeyAndElementSelectorWithComparer()
        {
            var source = new[] { "stack", "exchange", "Stack" };

            Assert.Throws<ArgumentException>(() =>
                source.ToDictionary(element => element, element => element, StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void KeyAndElementSelectorWithNullComparer()
        {
            var source = new[] { "stack", "exchange", "Stack" };
            IEqualityComparer<char> comparer = null;

            var actual = source.ToDictionary(element => element[0], element => element.Length, comparer);

            Assert.That(actual['s'], Is.EqualTo(5));
            Assert.That(actual['S'], Is.EqualTo(5));
            Assert.That(actual['e'], Is.EqualTo(8));
        }
    }
}