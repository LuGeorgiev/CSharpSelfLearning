using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkeletonTests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthAfterAttack()
        {
            var dummy = new Dummy(10, 20);

            dummy.TakeAttack(5);

            //Assert.That(dummy.Health, Is.EqualTo(5));
            Assert.AreEqual(5, dummy.Health);

        }
    }
}
