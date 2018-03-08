using System;
using System.Linq;
using NUnit.Framework;
using Utilities;

namespace Utility.Test.NUnit
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void ThrowArgumentExceptionWhenListISNull()
        {
            //arrange
            var utils = new MathUtils();

            //act & assert
            Assert.Throws<ArgumentException>(() => utils.Sum(null));
        }
    }
}
