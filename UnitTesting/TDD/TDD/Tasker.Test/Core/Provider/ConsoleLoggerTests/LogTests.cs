using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core.IdProviders;

namespace Tasker.Test.Core.Provider.ConsoleLoggerTests
{
    [TestFixture]
    public class LogTests
    {
        [Test] //Following test is not RECOMENDED APPROACH
        public void Log_ShouldLogToConsole_When_Invoked() //This is INTEGRATION test NOT UNIT
        {
            //Arrange
            var message = "Pesho";
            var sut = new ConsoleLogger();

            var outputStraem = new StringWriter();
            var defaultStream = Console.Out;
            Console.SetOut(outputStraem);

            //Act
            sut.Log(message);

            //Asser
            Assert.AreEqual(message+Environment.NewLine, outputStraem.ToString());
            Console.SetOut(defaultStream);//to set console to initial state
        }
    }
}
