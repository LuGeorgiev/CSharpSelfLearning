using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vechicles
{
    public class Truck : Vehicle
    {
        private const double FUEL_SUMMER_INCREASE = 1.6;
        private const double FUEL_LEACKAGE_REDUCTION = 0.95;

        private double fuelAvailable;
        private double fuelConsumption;

        public Truck(double initialFuel, double litterPerKm):base(initialFuel,litterPerKm)
        {
            this.FuelConsumption = litterPerKm + FUEL_SUMMER_INCREASE;
            this.FuelAvailable = initialFuel;
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
            this.FuelAvailable += litters * FUEL_LEACKAGE_REDUCTION;
        }
       
    }
}
