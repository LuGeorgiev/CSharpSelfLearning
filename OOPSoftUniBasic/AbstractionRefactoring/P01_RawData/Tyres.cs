using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Tyres
    {
        public KeyValuePair<double, int>[] tires;

        public Tyres(double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age),
                KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };

        }
    }
}
