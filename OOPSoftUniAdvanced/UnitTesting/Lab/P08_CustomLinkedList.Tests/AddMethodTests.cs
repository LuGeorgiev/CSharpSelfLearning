using CustomLinkedList;
using NUnit.Framework;
using System;

namespace P08_CustomLinkedList.Tests
{
    [TestFixture]
    public class AddMethodTests
    {
        [Test]
        public void ConstructorCreatesCorrectInstance()
        {
            IDynamicList<string> sut = new DynamicList<string>();

            Assert.That(sut, Is.AssignableFrom(typeof(DynamicList<string>)));
        }

        [Test]
        public void InitallyListIsEmpty()
        {
            IDynamicList<string> sut = new DynamicList<string>();

            Assert.That(sut.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldIncreaseCount_WhenNewItemIsAdded()
        {
            string itemToAdd = "element";
            IDynamicList<string> sut = new DynamicList<string>();

            sut.Add(itemToAdd);

            Assert.That(sut.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddedElementIsCorrectlyAddedAtLastPosition()
        {
            string itemToAdd = "element";
            IDynamicList<string> sut = new DynamicList<string>();

            sut.Add(itemToAdd);

            Assert.That(sut[0], Is.EqualTo(itemToAdd));
        }

        [Test]
        public void OutOfRangeExceptiomSouldBeThrownIfIndexIsNotInRange()
        {            
            IDynamicList<string> sut = new DynamicList<string>();            

            Assert.That(()=>sut[1], Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
