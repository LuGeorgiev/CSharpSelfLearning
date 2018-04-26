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
            var carTrunkCap = double.Parse(carInput[3]);
            IVehicle car = new Car(carTrunkCap,carFuel, carConsumption);

            var truckInput = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckInput[1]);
            var truckConsumption = double.Parse(truckInput[2]);
            var truckTrunkCap = double.Parse(truckInput[3]);
            IVehicle truck = new Truck(truckTrunkCap,truckFuel, truckConsumption);

            //Problem 2
            var busInput = Console.ReadLine().Split();
            var busFuel = double.Parse(busInput[1]);
            var busConsumption = double.Parse(busInput[2]);
            var busTrunkCap = double.Parse(busInput[3]);
            IVehicle bus = new Bus(busTrunkCap, busFuel, busConsumption);

            var entries = int.Parse(Console.ReadLine());
            for (int i = 0; i < entries; i++)
            {
                var input = Console.ReadLine().Split();
                var vehicle = input[1];
                var action = input[0];
                var quantity = double.Parse(input[2]);

                //Problem 1
                //ParseCommand(action,vehicle,quantity,car, truck);
                try
                {
                    ParseCommand(action, vehicle, quantity, car, truck, bus);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ParseCommand(string action, string vehicle, double quantity, IVehicle car, IVehicle truck, IVehicle bus)
        {
            if (action == "Drive")
            {
                if (vehicle == "Car")
                {
                    car.TravellDistance(quantity);
                }
                else if(vehicle == "Truck")
                {
                    truck.TravellDistance(quantity);
                }
                else
                {
                    bus.TravellDistance(quantity);
                }
            }
            else if(action == "Refuel")
            {
                if (vehicle == "Car")
                {
                    car.AddFuel(quantity);
                }
                else if(vehicle == "Truck")
                {
                    truck.AddFuel(quantity);
                }
                else
                {
                    bus.AddFuel(quantity);
                }
            }
            else
            {
                Bus newBus = (Bus)bus;
                newBus.TravelWithoutPeople(quantity);
            }
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
