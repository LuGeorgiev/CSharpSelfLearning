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

        public Vehicle(double fuelAvailable,double fuelConsumption)
        {
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumption = fuelConsumption;
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

        public abstract void AddFuel(double litters);

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
