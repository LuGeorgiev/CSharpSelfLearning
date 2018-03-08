using System;
using Moq;
using NUnit.Framework;
using Tasker.Core;
using Tasker.Core.Contracts;
using Tasker.Models.Contracts;
using Tasker.Test.Core.TaskManagerTests.Fakes;

namespace Tasker.Test.Core.TaskManagerTests
{
    [TestFixture]
    public class AddTests
    {
        [Test]
        public void Add_ShouldThrownullException_WhenPassedNullValue()
        {
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();
            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);
            

            Assert.Throws<ArgumentNullException>(()=>sut.Add(null));
        }

        [TestCase(0)]
        [TestCase(5)]
        public void Add_ShouldAssignIdToProvidedTask_WhenValidTaskIsPassed(int expectedValue)
        {
            
            var taskMock = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();

            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);

            idProviderStub.Setup(x => x.NextId()).Returns(expectedValue); // not needed if x.Id=0 in Assert. 0 is default value and should not be used
            //Setup can controll behaviour of Stubs

            //act
            sut.Add(taskMock.Object);

            //Assert
            taskMock.VerifySet(x => x.Id = expectedValue);
        }

        [Test]
        public void Add_ShouldLogMessage_WhenProvidedTaskToCollection()
        {
            var taskStub = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerMock = new Mock<ILogger>();
            var sut = new TaskManager(idProviderStub.Object, consoleLoggerMock.Object);

            sut.Add(taskStub.Object);
            consoleLoggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once); //It.Is any string - id dors not matter how is invoked, any string will be valid
        }

        [Test]
        public void Add_ShouldAddTaskToCollection_WhenProvidedTaskIsValid()
        {
            var taskStub = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();
            var sut = new TaskManagerFake(idProviderStub.Object, consoleLoggerStub.Object); //FAKED not using private fields
            // we cannot access protected field of TAskMAnager this is why FAKE have to be created that can be accessed

            sut.Add(taskStub.Object);

            Assert.That(() => sut.ExposedTasks.Contains(taskStub.Object));
        }
    }
}
