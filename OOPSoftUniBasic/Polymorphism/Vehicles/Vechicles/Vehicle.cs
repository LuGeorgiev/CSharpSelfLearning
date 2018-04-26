using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Vechicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelAvailable;
        private double fuelConsumption;

        public Vehicle(double tankCapacity, double fuelAvailable,double fuelConsumption)
        {
            if (fuelAvailable> tankCapacity)
            {
                fuelAvailable = 0;
            }
                this.TankCapacity = tankCapacity;
                this.FuelConsumption = fuelConsumption;
            try
            {
                this.FuelAvailable = fuelAvailable;
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public double TankCapacity { get; set; }

        public virtual double FuelAvailable
        {
            get
            {
                return this.fuelAvailable;
            }
            set
            {
                if ( value > this.TankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {value:0.##} fuel in the tank");
                }               
                this.fuelAvailable = value;
            }
        }

        public virtual double FuelConsumption
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

        public virtual void AddFuel(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            else if (this.FuelAvailable+ value > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {value:0.##} fuel in the tank");
            }
            this.FuelAvailable += value;
        }

        public virtual void TravellDistance(double kilometers)
        {
            bool canPassDistabce = this.FuelAvailable / this.FuelConsumption >= kilometers;
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

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelAvailable:F2}";
        }
    }
}
