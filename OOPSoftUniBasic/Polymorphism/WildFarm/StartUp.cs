using System;
using System.Collections.Generic;
using WildFarm.Classes;
using WildFarm.Classes.Animals;
using WildFarm.Contracts;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = "";
            var animals = new List<IAnimal>();

            while ((input=Console.ReadLine())!="End")
            {
                IAnimal nextAnimal = ParseAnimals(input);

                var foodInput = Console.ReadLine().Split();
                var foodType = foodInput[0];
                var foodQuantity = int.Parse(foodInput[1]);
                IFood food = new Food(foodType, foodQuantity);

                nextAnimal.ProduceSound();
                nextAnimal.IncreaseWeight(food);

                animals.Add(nextAnimal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static IAnimal ParseAnimals(string input)
        {
            var tokens = input.Split();
            var animalType = tokens[0];
            var name = tokens[1];

            if (animalType == "Hen")
            {                
                var wings = double.Parse(tokens[3]);
                var weight = double.Parse(tokens[2]);

                return new Hen(name, wings, weight);
            }
            else if (animalType == "Owl")
            {                
                var wings = double.Parse(tokens[3]);
                var weight = double.Parse(tokens[2]);

                return new Owl(name, wings, weight);
            }
            else if (animalType == "Mouse")
            {
                var weight = double.Parse(tokens[2]);
                var region = tokens[3];

                return new Mouse(name, weight, region);
            }
            else if (animalType == "Dog")
            {
                var weight = double.Parse(tokens[2]);
                var region = tokens[3];

                return new Dog(name, weight, region);
            }
            else if (animalType == "Cat")
            {
                var breed = tokens[4];
                var weight = double.Parse(tokens[2]);
                var region = tokens[3];

                return new Cat(region, name, weight, breed);
            }           
            else if (animalType == "Tiger")
            {
                var breed = tokens[4];
                var weight = double.Parse(tokens[2]);
                var region = tokens[3];

                return new Tiger(region, name, weight, breed);
            }
            else
            {
                throw new ArgumentException("Invalid animal input");
            }
        }
    }
}
