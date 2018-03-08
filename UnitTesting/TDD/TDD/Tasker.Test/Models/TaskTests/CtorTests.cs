using NUnit.Framework;
using Tasker.Models;

namespace Tasker.Test.Models.TaskTests
{
    [TestFixture]
    public class CtorTests
    {
        [Test]
        public void Ctor_ShouldAssignDescription_WhenInvoked(string description)
        {
            //Arrange && Act
            var expected = "Valid Description";
            var sut = new Task(expected);

            //Assert
            Assert.AreEqual(expected, sut.Description);
        }
    }
}
