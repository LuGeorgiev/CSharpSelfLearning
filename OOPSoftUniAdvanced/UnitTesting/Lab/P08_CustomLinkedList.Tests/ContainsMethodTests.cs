using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_CustomLinkedList.Tests
{
    [TestFixture]
    public class ContainsMethodTests
    {
        [Test]
        public void Contains_ShouldReturTrue_IfValueExist()
        {
            string itemToAdd = "element";
            IDynamicList<string> sut = new DynamicList<string>();

            sut.Add(itemToAdd);

            Assert.That(()=>sut.Contains(itemToAdd), Is.True);
        }

        [Test]
        public void Contains_ShouldReturFalse_IfValueNotExist()
        {
            string itemToAdd = "element";
            string notExisting = "noexist";
            IDynamicList<string> sut = new DynamicList<string>();

            sut.Add(itemToAdd);

            Assert.That(() => sut.Contains(notExisting), Is.False);
        }
    }
}
