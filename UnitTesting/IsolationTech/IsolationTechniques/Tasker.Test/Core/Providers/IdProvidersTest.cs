
using Lecture.Core.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasker.Test.Core.Providers
{
    [TestFixture]
    public class IdProvidersTest
    {
        [Test]
        public void NextId_SouldReturnIncrementedValue_WhenInvoked()
        {
            var sut = new IdProvider();
            var resultOne = sut.NextId();
            var resultTwo = sut.NextId();

            Assert.AreEqual(0, resultOne);
            Assert.AreEqual(1, resultTwo);
        }
    }
}
