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
        [Test]
        public void PrintMethod_PrintTheCurrentElementInCollection()
        {
            var stringArr = new[] { "a", "b" };
            var firstElemet = "a"; 
            IListyItaerator<string> sut = new ListyItaerator<string>(stringArr);

            Assert.That(() => sut.Print(), Is.EqualTo(firstElemet));
        }
        [Test]
        public void PrintAllMethod_PrintsAllElementsInCollection()
        {
            var stringArr = new[] { "a", "b", "c" };
            var elements = "a b c";
            IListyItaerator<string> sut = new ListyItaerator<string>(stringArr);

            Assert.That(() => sut.PrintAll(), Is.EqualTo(elements));
        }

    }
}
