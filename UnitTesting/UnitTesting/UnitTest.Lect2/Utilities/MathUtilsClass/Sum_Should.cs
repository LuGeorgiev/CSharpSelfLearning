using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Utilities;

//MS Test V2
namespace UnitTest.Lect2.Utilities.MathUtilsClass
{
    [TestClass]
    class Sum_Should
    {
        //private MathUtils utils;
        //[TestInitialize]                  // not recomended pratcice
        //public void TestInit()
        //{
        //    utils = new MathUtils();
        //}

        [TestMethod]    
        public void ThrowAnArgumentExeption_WhenTheListIsNull()
        {
            //arrange
            var utils = new MathUtils();

            //act+assert phase
            Assert.ThrowsException<ArgumentException>(() => utils.Sum(null));
        }

        [TestMethod]
        public void ReturnZero_IfTheLisiIsEmpty()
        {
            //arrange
            var utils = new MathUtils();
            var list = new List<int>();

            //act
            var result = utils.Sum(list);

            //assert
            Assert.AreEqual(0,result);
        }
    }
}
