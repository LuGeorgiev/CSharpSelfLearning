using NUnit.Framework;
using System;
using Tasker.Core.IdProviders;

namespace Tasker.Test.Core.Provider.IdProviderTests
{
    [TestFixture]
    public class NextIdTests
    {
        [Test]
        public void NextId_SouldReturnIncrementedValue_WhenInvoked()
        {
            var sut = new IdProvider();
            var resultOne = sut.NextId();
            var resultTwo = sut.NextId();

            Assert.AreEqual(0,resultOne);
            Assert.AreEqual(1,resultTwo);
        }
    }
}
