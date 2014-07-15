using System;
using System.Collections.Generic;
using EmuLinq.Test.Support;
using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class SelectManyTest
    {
        [Test]
        public void ExecutionIsDeferred()
        {
            new ThrowingEnumerable().SelectMany(x => new int[1]);
        }

        [Test]
        public void SimpleFlatten()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            var result = source.SelectMany(group => group.Split(' '));

            // assert
            CollectionAssert.AreEquivalent(
                new[] { "Mexico", "Brazil", "Australia", "Netherlands" }, result);
        }

        [Test]
        public void SimpleFlattenWithIndex()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            var result = source.SelectMany(
                (group, groupIndex) => group.Split(' ').Select(country => groupIndex + " " + country));

            // assert
            var expected = new[]
            {
                "0 Mexico",
                "0 Brazil",
                "1 Australia",
                "1 Netherlands"
            };
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void FlattenWithProjection()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            var result =
                source.SelectMany(
                    group => group.Split(' '), (group, country) => group + " > " + country);

            // assert
            CollectionAssert.AreEquivalent(new[] 
            {
                "Mexico Brazil > Mexico",
                "Mexico Brazil > Brazil",
                "Australia Netherlands > Australia",
                "Australia Netherlands > Netherlands"
            }, result);
        }

        [Test]
        public void FlattenWithProjectionAndIndex()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            var result =
                source.SelectMany(
                    (group, index) => group.Split(' ').Select(country => index + " " + country),
                    (group, country) => group + " > " + country);

            // assert
            CollectionAssert.AreEquivalent(new[]
            {
                "Mexico Brazil > 0 Mexico",
                "Mexico Brazil > 0 Brazil",
                "Australia Netherlands > 1 Australia",
                "Australia Netherlands > 1 Netherlands"
            }, result);
        }

        [Test]
        public void NullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<string> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.SelectMany(s => s));
        }

        [Test]
        public void NullSelectorThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() =>
                source.SelectMany((Func<string, IEnumerable<char>>)null));
        }

        [Test]
        public void WithIndexNullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<string> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.SelectMany((s, index) => s));
        }

        [Test]
        public void WithIndexNullSelectorThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() =>
                source.SelectMany((Func<string, int, IEnumerable<char>>)null));
        }

        [Test]
        public void WithProjectionNullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<string> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.SelectMany(s => s, (s, c) => c));
        }

        [Test]
        public void WithProjectionNullCollectionSelectorThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() =>
                source.SelectMany((Func<string, IEnumerable<char>>)null, (s, c) => c));
        }

        [Test]
        public void WithProjectionNullResultCollectionSelectorThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() =>
                source.SelectMany(s => s, null));
        }

        [Test]
        public void WithProjectionAndIndexNullSourceThrowsArgumentNullException()
        {
            // arrange
            IEnumerable<string> source = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => source.SelectMany((s, index) => s, (s, c) => c));
        }

        [Test]
        public void WithProjectionAndIndexNullCollectionSelectorThrowsArgumentNullException()
        {
            // arrange
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() =>
                source.SelectMany((Func<string, int, IEnumerable<char>>)null, (s, c) => c));
        }

        [Test]
        public void WithProjectionAndIndexNullResultSelectorThrowsArgumentNullException()
        {
            // act
            var source = new[] { "Mexico Brazil", "Australia Netherlands" };

            // arrange
            // assert
            Assert.Throws<ArgumentNullException>(() =>
                source.SelectMany((s, i) => s, null));
        }
    }
}