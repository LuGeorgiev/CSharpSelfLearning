using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vechicles
{
    public class Car : Vehicle
    {
        private const double FUEL_SUMMER_INCREASE = 0.9;

        private double fuelAvailable;
        private double fuelConsumption;

        public Car(double initialFuel, double litterPerKm):base(initialFuel,litterPerKm)
        {
            this.FuelAvailable = initialFuel;
            this.FuelConsumption = litterPerKm + FUEL_SUMMER_INCREASE;
        }
        public override double FuelAvailable
        {
            get
            {
                return this.fuelAvailable;
            }
            set
            {
                this.fuelAvailable = value;
            }
        }

        public override double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }

        public override void AddFuel(double litters)
        {
            this.fuelAvailable += litters;
        }
        
    }
}
