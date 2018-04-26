using System;
using Vehicles.Contracts;
using Vehicles.Vechicles;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split();
            var carFuel = double.Parse(carInput[1]);
            var carConsumption = double.Parse(carInput[2]);
            IVehicle car = new Car(carFuel, carConsumption);

            var truckInput = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckInput[1]);
            var truckConsumption = double.Parse(truckInput[2]);
            IVehicle truck = new Truck(truckFuel, truckConsumption);

            var entries = int.Parse(Console.ReadLine());
            for (int i = 0; i < entries; i++)
            {
                var input = Console.ReadLine().Split();
                var vehicle = input[1];
                var action = input[0];
                var quantity = double.Parse(input[2]);

                ParseCommand(action,vehicle,quantity,car, truck);
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ParseCommand(string action, string vehicle, double quantity, IVehicle car, IVehicle truck)
        {
            if (action=="Drive")
            {
                if (vehicle=="Car")
                {
                    car.TravellDistance(quantity);
                }
                else
                {
                    truck.TravellDistance(quantity);
                }
            }
            else
            {
                if (vehicle == "Car")
                {
                    car.AddFuel(quantity);
                }
                else
                {
                    truck.AddFuel(quantity);
                }
            }
        }
    }
}
