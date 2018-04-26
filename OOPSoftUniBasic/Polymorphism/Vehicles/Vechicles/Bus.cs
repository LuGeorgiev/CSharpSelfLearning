using System;


namespace Vehicles.Vechicles
{

    public class Bus : Vehicle
    {
        private const double FUEL_SUMMER_INCREASE = 1.4;

        public Bus(double tankCapacity, double fuelAvailable, double fuelConsumption) : base(tankCapacity, fuelAvailable, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + FUEL_SUMMER_INCREASE;
        }
               

        public void TravelWithoutPeople(double kilometers)
        {
            bool canPassDistabce = this.FuelAvailable / (this.FuelConsumption-FUEL_SUMMER_INCREASE) >= kilometers;
            if (canPassDistabce)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {kilometers:0.######} km");
                this.FuelAvailable -= kilometers * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
