using System;
using System.Collections.Generic;

namespace P06_Animals
{
    class StartUp
    {
        static void Main(string[] args)
        {

            string animalType = "";
            List<Animal> animals = new List<Animal>();
            
            while ((animalType=Console.ReadLine())!= "Beast!")
            {
                try
                {
                    ReadAndCreatAnimals(animals, animalType);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void ReadAndCreatAnimals(List<Animal> animals, string animalType)
        {
            var tokens = Console.ReadLine().Split();
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            string gender = null;
            if (tokens.Length == 3)
            {
                gender = tokens[2];
            }

            switch (animalType)
            {
                case "Cat":
                    var cat = new Cat(name, age, gender);
                    animals.Add(cat);
                    break;
                case "Dog":
                    var dog = new Dog(name, age, gender);
                    animals.Add(dog);
                    break;
                case "Frog":
                    var frog = new Frog(name, age, gender);
                    animals.Add(frog);
                    break;
                case "Kitten":
                    var kitten = new Kitten(name, age);
                    animals.Add(kitten);
                    break;
                case "Tomcat":
                    var tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                    break;
                default:
                    throw new ArgumentException("Invalid input!");
                    break;
            }
        }
    }
}
