using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vechicles
{
    public class Truck : Vehicle
    {
        private const double FUEL_SUMMER_INCREASE = 1.6;
        private const double FUEL_LEACKAGE_REDUCTION = 0.95;        

        public Truck(double tankCapacity,double initialFuel, double litterPerKm):base(tankCapacity,initialFuel,litterPerKm)
        {            
            this.FuelConsumption = litterPerKm + FUEL_SUMMER_INCREASE;            
        }
        

        public override void AddFuel(double value)
        {
            if (value <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (this.FuelAvailable + value > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {value:0.###} fuel in the tank");
            }
            this.FuelAvailable += value * FUEL_LEACKAGE_REDUCTION;
        }
       
    }
}
