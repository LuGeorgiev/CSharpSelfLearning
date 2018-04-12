using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Car
    {
        
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            double t1Pressure, int t1Age, double t2Pressure, int t2Age, double t3Pressure, int t3age, double t4Pressure, int t4age)
        {
            this.model = model;
            this.engine = new Engine(engineSpeed, enginePower);
            this.cargo = new Cargo(cargoWeight, cargoType);
            this.tires = new Tyres(t1Pressure, t1Age, t2Pressure, t2Age, t3Pressure, t3age, t4Pressure, t4age );
        }
        public string model;
        public Engine engine;
        public Cargo cargo;
        public Tyres tires;       
        
    }
}
