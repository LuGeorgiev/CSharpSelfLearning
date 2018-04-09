using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class RawStart
    {
        static void Main(string[] args)
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var listOfCars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                var model = data[0];
                var engSpeed = int.Parse(data[1]);
                var engPower = int.Parse(data[2]);
                var cargoWeight = int.Parse(data[3]);
                var cargoType = data[4];
                var t1pres = double.Parse(data[5]);
                var t1age = int.Parse(data[6]);
                var t2pres = double.Parse(data[7]);
                var t2age = int.Parse(data[8]);
                var t3pres = double.Parse(data[9]);
                var t3age = int.Parse(data[10]);
                var t4pres = double.Parse(data[11]);
                var t4age = int.Parse(data[12]);

                listOfCars.Add(new Car(model, engSpeed, engPower, cargoWeight, cargoType,
                    t1pres, t1age, t2pres, t2age, t3pres, t3age, t4pres, t4age));
            }

            var command = Console.ReadLine();
            if (command== "fragile")
            {
                var filteredCars = listOfCars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Tyres.Tyre1Presure < 1 || x.Tyres.Tyre2Presure < 1 ||
                    x.Tyres.Tyre3Presure < 1 || x.Tyres.Tyre4Presure < 1);

                PrintFiltered(filteredCars);
            }
            else
            {
                var filteredCars = listOfCars
                    .Where(x => x.Cargo.Type == "flamable")
                    .Where(x => x.Engine.Power > 250);

                PrintFiltered(filteredCars);
            }
        }

        private static void PrintFiltered(IEnumerable<Car> filterdCars)
        {
            foreach (var car in filterdCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
