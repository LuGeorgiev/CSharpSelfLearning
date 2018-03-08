using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Test.Models.TaskTests
{
    [TestFixture]
    class IdTest
    {
        [TestCase(-1)]
        [TestCase(-10)]
        public void Id_ShouldThrwArgumentExeption_WhenPassedValueInInvalidRAnge(int value)
        {
            //Arramge
            var sut = new Task("Valid Description");

            //Act && Assert
            Assert.Throws<ArgumentException>(()=>sut.Id = value);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Id_ShouldNotThrow_WhemPassedPositiveValues(int value)
        {
            //Arrabnge
            var sut = new Task("Valid Description");

            //Act && Assert
            Assert.DoesNotThrow(()=>sut.Id=value);           
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Id_SuldSetPassedValue_WhenPassedValueIsValiD(int value)
        {
            //Arrabnge
            var sut = new Task("Valid Description");

            //Act
            sut.Id = value;

            //Asert
            Assert.AreEqual(value,sut.Id);
        }

    }
}
