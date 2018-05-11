using NUnit.Framework;
using P02_ListIterator;
using System;

namespace P02_ListIteratorTests
{
    [TestFixture]
    public class ListIteratirTests
    {
        [Test]
        public void Constructor_ShouldSetElements()
        {
            var stringArr = new[] { "a", "b", "c" };

            IListyItaerator<string> sut = new ListyItaerator<string>(stringArr);

            Assert.That(sut.Elements, Is.EquivalentTo(stringArr));
        }

        [Test]
        public void Constructor_ShouldSThrowExeption_IfNullArgumentAssigned()
        {   
            Assert.That(()=>new ListyItaerator<string>(null), Throws.ArgumentNullException);
        }

        [Test]
        public void MoveMethod_ShouldIncrementIndex()
        {
            var stringArr = new[] { "a", "b", "c" };
            int firstIndexPosition = 1;
            IListyItaerator<string> sut = new ListyItaerator<string>(stringArr);

            sut.MoveTo();

            Assert.That(sut.Index, Is.EqualTo(firstIndexPosition));
        }

        [Test]
        public void MoveMethod_ShouldReturnFalseInNoNextIndexExists()
        {
            var stringArr = new[] {"a"};            
            IListyItaerator<string> sut = new ListyItaerator<string>(stringArr);
            sut.MoveTo();

            Assert.That(()=>sut.MoveTo(), Is.False);
        }

        [Test]
        public void MoveMethod_ShouldReturnTrueIfNextIndexExists()
        {
            var stringArr = new[] { "a","b" };
            IListyItaerator<string> sut = new ListyItaerator<string>(stringArr);            

            Assert.That(() => sut.MoveTo(), Is.True);
        }
    }
}
