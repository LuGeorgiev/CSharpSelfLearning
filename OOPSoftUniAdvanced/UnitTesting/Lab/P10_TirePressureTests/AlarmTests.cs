using Moq;
using NUnit.Framework;
using P10_TirePressureMonitoringSystem;
using System;
using System.Collections.Generic;
using System.Text;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace P10_TirePressureTests
{
    [TestFixture]
    public class AlarmTests
    {
        [TestCase(1.1)]
        [TestCase(2.1)]
        [TestCase(4.9)]
        public void AlarmOn_IsTrue_WhenPsiIs_InRange(double psiOffest)
        {
            var randPsiStub = new Mock<IRandomPsi>();
            randPsiStub.Setup(r => r.ReadPressureSample()).Returns(psiOffest);
            var sensor = new Sensor();

            IAlarm sut = new Alarm();
            sut.Check(sensor,randPsiStub.Object);

            Assert.That(sut.AlarmOn, Is.False);
        }

        [TestCase(0.2)]
        [TestCase(5.5)]
        [TestCase(5.2)]
        [TestCase(0.30)]
        public void AlarmOn_IsTrue_WhenPsiIs_OutOfRange(double psiOffest)
        {
            var randPsiStub = new Mock<IRandomPsi>();
            randPsiStub.Setup(r => r.ReadPressureSample()).Returns(psiOffest);
            var sensor = new Sensor();

            IAlarm sut = new Alarm();
            sut.Check(sensor, randPsiStub.Object);

            Assert.That(sut.AlarmOn, Is.True);

        }
    }
}
