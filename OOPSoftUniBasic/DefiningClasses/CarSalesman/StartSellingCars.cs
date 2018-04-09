using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartSellingCars
    {
        static void Main(string[] args)
        {
            var enginesList = new List<Engine>();
            var enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                var engineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInput[0];
                string power = engineInput[1];
                string displacement = "n/a";
                string efficiency = "n/a";
                if (engineInput.Length == 4)
                {
                    displacement = engineInput[2];
                    efficiency = engineInput[3];
                }
                else if (engineInput.Length == 3)
                {
                    if (48<=engineInput[2][0]&& engineInput[2][0]<=57)
                    {
                        displacement = engineInput[2];
                    }
                    else
                    {
                        efficiency = engineInput[2];
                    }
                }

                enginesList.Add(new Engine(model,power,displacement,efficiency));
            }

            var carList = new List<Car>();
            var carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInput[0];
                string engine = carInput[1];
                string weight = "n/a";
                string color = "n/a";
                if (carInput.Length == 4)
                {
                    weight = carInput[2];
                    color = carInput[3];
                }
                else if (carInput.Length == 3)
                {
                    if (48 <= carInput[2][0] && carInput[2][0] <= 57)
                    {
                        weight = carInput[2];
                    }
                    else
                    {
                        color = carInput[2];
                    }
                }

                Engine usedEngine = enginesList.FirstOrDefault(x => x.Model == engine);
                carList.Add(new Car(model,usedEngine,weight,color));
            }

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

        }
    }
}
