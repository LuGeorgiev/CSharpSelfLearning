using NUnit.Framework;
using Lecture.Core;
using Lecture.Modules;
using Tasker.Test.Core.Fakes;
using Lecture.Core.Providers.Contract;
using Moq;
using Lecture.Modules.Contracts;
using Lecture.Core.Contracts;

namespace Tasker.Test.Core
{
    [TestFixture]
    public class Tasker
    {
        [Test]
        public void Add_ShouldLogSuccessfillMessage_WhenPassedValidTask()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            var idProviderStub = new Mock<IIdProvider>();
            var taskStub = new Mock<ITask>();

            var manger = new TaskManager(idProviderStub.Object, loggerMock.Object);
            var list = new List();

            //// if two thisng are created this is Integration test
            //var task = new Task("some description"); 
            //var task = new FakeTask("some");

            //Act
            manger.Add(taskStub.Object);


            //Assert
            loggerMock.Verify(x=>x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Add_ShouldCorrectlyAssignTaskIds_WhenValidTaskIsProvided()
        {
            //Arrange
            var expectedId = 0;

            var loggerStub = new Mock<ILogger>();
            var idProviderStub = new Mock<IIdProvider>();
            var taskMock = new Mock<ITask>();

            idProviderStub.Setup(x => x.NextId()).Returns(expectedId);
            //taskOneStub.SetupGet(x => x.Description).Returns("pesho");
            //taskTwoStub.SetupGet(x => x.Description).Returns("gosho");

            var manger = new TaskManager(idProviderStub.Object, loggerStub.Object);

            //act
            manger.Add(taskMock.Object);

            //Assert
            taskMock.Verify(x => x.Id == expectedId);
        }

    }
}
