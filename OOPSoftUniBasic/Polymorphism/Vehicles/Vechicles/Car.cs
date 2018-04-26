using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vechicles
{
    public class Car : Vehicle
    {
        private const double FUEL_SUMMER_INCREASE = 0.9;
        

        public Car(double tankCapacity, double initialFuel, double litterPerKm):base(tankCapacity,initialFuel,litterPerKm)
        {
            
            this.FuelConsumption = litterPerKm + FUEL_SUMMER_INCREASE;
        }
        
    }
}
