using System.Collections.Generic;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SelectManyTest
    {
        [Test]
        public void SimpleFlatten()
        {
            // arrange
            var sentences = new List<string> { "Hello World", "Goodbye World" };

            // act
            var result = sentences.SelectMany(n => n.Split(' '));

            // assert
            Assert.That(result.Count(), Is.EqualTo(4));

            CollectionAssert.AreEquivalent(
                new[] { "Hello", "World", "Goodbye", "World" }, result);
        }

        [Test]
        public void SimpleFlattenWithIndex()
        {
            // arrange
            var sentences = new List<string> { "Hello World", "Goodbye World" };

            // act
            var result = sentences.SelectMany((s, i) => s.Split(' ').Select(x => i + " " + x));

            // assert
            var expected = new[]
            {
                "0 Hello",
                "0 World",
                "1 Goodbye",
                "1 World"
            };
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}