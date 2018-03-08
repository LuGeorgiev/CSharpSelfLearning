using System;
using NUnit.Framework;
using UnitTesting.GettingStarted;

namespace UnitTesting.GettingStarted.Test
{
    [TestFixture]
    public class UnitTestingUtility
    {
        [Test]
        public void AddAlwaysReturnSumOfTwoDigits()
        {
            var systemUnderTest = new Calculator();
            Assert.That(systemUnderTest.Add(1, 2), Is.EqualTo(3));
        }
    }
}
