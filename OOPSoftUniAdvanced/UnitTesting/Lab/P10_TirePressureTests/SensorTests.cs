using Moq;
using NUnit.Framework;
using P10_TirePressureMonitoringSystem;
using System;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace P10_TirePressureTests
{
    [TestFixture]
    public class SensorTests
    {
        [TestCase(2.0)]
        [TestCase(3.5)]
        [TestCase(4.5)]
        public void PopNextPreasurePsiLevel_ShouldReturnArgumentInRange(double valuInRange)
        {
            var randPsiStub = new Mock<IRandomPsi>();
            randPsiStub.Setup(s => s.ReadPressureSample()).Returns(valuInRange);

            var sensor = new Sensor();        
            
            Assert.That(() => sensor.PopNextPressurePsiValue(randPsiStub.Object), Is.EqualTo(valuInRange + 16.0));
        }

        [TestCase(0.0)]
        [TestCase(-3.5)]
        [TestCase(10.5)]
        public void PopNextPreasurePsiLevel_ShouldReturnArgumentOutOfRange(double valuInRange)
        {
            var randPsiStub = new Mock<IRandomPsi>();
            randPsiStub.Setup(s => s.ReadPressureSample()).Returns(valuInRange);

            var sensor = new Sensor();

            Assert.That(() => sensor.PopNextPressurePsiValue(randPsiStub.Object), Is.LessThan(17).Or.GreaterThan(21));
        }
    }
}
