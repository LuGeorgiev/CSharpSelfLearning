using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Car
    {
        public string Model { get; private set; }

        public CargoInfo Cargo { get; private set; }

        public EngineInfo Engine { get; private set; }

        public TyreInfo Tyres { get; private set; }

        public Car(string model,int engineSpeed,int enginePower,int cargoWeight,string cargoType,
            double tire1Pressure, int tire1Age,double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.Engine = new EngineInfo(engineSpeed, enginePower);
            this.Cargo = new CargoInfo(cargoWeight, cargoType);
            this.Tyres = new TyreInfo(tire1Age, tire1Pressure, tire2Age, tire2Pressure, tire3Age, tire3Pressure, tire4Age, tire4Pressure);
        }
    }
}
