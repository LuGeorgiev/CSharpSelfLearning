using NUnit.Framework;
using System;

namespace SkeletonTests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLoosDurabilityAfterAttack()
        {
            var axe = new Axe(5, 10);
            var dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            //Assert.AreEqual(9, axe.DurabilityPoints);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
            var axe = new Axe(5, 1);
            var dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), 
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }

    }
}
