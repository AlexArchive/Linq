using NUnit.Framework;

namespace EmuLinq.Test
{
    [TestFixture]
    public class EmptyTest
    {
        [Test]
        public void EmptyContainsNoElements()
        {
            // act
            // assert
            CollectionAssert.IsEmpty(Enumerable.Empty<string>());
        }

        [Test]
        public void EmptyIsCached()
        {
            // act 
            // assert
            Assert.AreSame(Enumerable.Empty<int>(), Enumerable.Empty<int>());
            Assert.AreSame(Enumerable.Empty<string>(), Enumerable.Empty<string>());
            Assert.AreSame(Enumerable.Empty<object>(), Enumerable.Empty<object>());
            Assert.AreNotSame(Enumerable.Empty<long>(), Enumerable.Empty<int>());
            Assert.AreNotSame(Enumerable.Empty<string>(), Enumerable.Empty<object>());
        }
    }
}