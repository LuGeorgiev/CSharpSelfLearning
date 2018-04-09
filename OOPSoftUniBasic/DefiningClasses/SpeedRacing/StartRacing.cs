using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartRacing
    {
        static void Main()
        {
            var carsList = new List<Car>();
            var numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var consumption = double.Parse(input[2]);
                carsList.Add(new Car(model, fuelAmount, consumption));
            }

            string nextCar = "";
            while ((nextCar=Console.ReadLine())!="End")
            {
                var carInfo = nextCar.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = carInfo[1];
                var distanceToTravel = int.Parse(carInfo[2]);

                var cuurentCar = carsList.FirstOrDefault(x => x.Model == model);
                cuurentCar.MoveDistance(distanceToTravel);
            }
            foreach (var car in carsList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }
        }
    }
}
