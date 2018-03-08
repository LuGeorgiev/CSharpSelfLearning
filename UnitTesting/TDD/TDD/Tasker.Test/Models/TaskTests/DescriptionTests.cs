using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Test.Models.TaskTests
{
    [TestFixture]
    public class DescriptionTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Description_ShouldThrowArgumentNullException_WhenPassedNullOrEmpty(string value)
        {
            //Arrange
            var sut = new Task("Valid Decription");

            //Act && Assert
            Assert.Throws<ArgumentNullException>(()=>sut.Description = value);
        }
    }
}
