using NUnit.Framework;
using P01_Database;
using System;

namespace P01_DatabaseTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void DatabaseConstructor_ShouldSetCorrectlyLessThanSexteenValues()
        {
            var initialArr = new int[] { 1, 2, 3 };
            var sut = new Database(initialArr);

            Assert.That(sut.MyArr[2], Is.EqualTo(initialArr[2]));
        }

        [Test]        
        public void DatabaseConstructor_ShouldThrowException_IfMoreThanSixteenElementsInitialized()
        {
            var initialArr = new int[] { 1, 2, 3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,17};
            
            Assert.That(() => new Database(initialArr), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethod_ShouldAddIntegers()
        {
            var initialArr = new int[] { 1, 2, 3 };
            int numberToadd = 4;
            var sut = new Database(initialArr);

            sut.Add(numberToadd);

            Assert.That(sut.MyArr[3], Is.EqualTo(numberToadd));
        }

        [Test]
        public void AddMethod_ShouldThrowException_IfThanSixteenElementExist()
        {
            int numberToadd = 4;
            var initialArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
            var sut = new Database(initialArr);


            Assert.That(() => sut.Add(numberToadd), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveMethod_ShouldReplaceWithZeroLastElement()
        {
            var initialArr = new int[] { 1, 2, 3 };
            var sut = new Database(initialArr);

            sut.Remove();

            Assert.That(sut.MyArr[2], Is.EqualTo(0));
        }
        [Test]
        public void RemoveMethod_ShouldThrowException_IfRemoveFromEmptyArr()
        {
            var sut = new Database();

            Assert.That(() => sut.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FetchMethod_ShouldReturnTheWholeArray()
        {
            var initialArr = new int[] { 1, 2, 3 };
            var sut = new Database(initialArr);


            Assert.That(() => sut.Fetch(), Has.Member(3));
        }

    }
}
