using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        private string model;
        private double consumption;
        private double fuelAmount;
        private int distanceTraveled;

        public int DistanceTraveled { get; private set; } = 0;
        public string Model
        {
            get { return model; }
            private set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            private set { fuelAmount = value; }
        }
        public double Consumption
        {
            get { return consumption; }
            private set { consumption = value; }
        }

        public Car(string model, double amount, double consumption)
        {
            this.Model = model;
            this.FuelAmount = amount;
            this.Consumption = consumption;
        }
        public void MoveDistance(int distance)
        {
            if (distance*this.Consumption>fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }
            else
            {
                this.DistanceTraveled += distance;
                this.FuelAmount -= distance * this.Consumption;
            }
        }
    }
}
