using System;
using System.Collections.Generic;
using System.Text;

namespace P10_TirePressureMonitoringSystem
{
    public class GenerateRandomPsi : IRandomPsi
    {
        readonly Random _randomPressureSampleSimulator = new Random();

        public double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();
        }
    }
}
