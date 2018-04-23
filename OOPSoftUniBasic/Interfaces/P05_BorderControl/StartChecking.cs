using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_BorderControl
{
    public class StartChecking
    {
        static void Main(string[] args)
        {
            //// Problem 5 Border Controll
            //ICollection<IId> citicentsId = InitializeIdInCity();
            //var faekIds = Console.ReadLine();
            //PrintFakeCitizens(citicentsId, faekIds);


            //// Problem 6. Birthday Celebrations
            //ICollection<IBirthdate> birthdates = new List<IBirthdate>();
            //birthdates = FillBirthdates();
            //var yearToPrint = Console.ReadLine();
            //PrintBorn(birthdates, yearToPrint);

            //Problem 7.Food Shortage
            ICollection<Human> foodBuyers = new List<Human>();
            var peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    var citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    foodBuyers.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    var rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    foodBuyers.Add(rebel);
                }
            }

            var hungryPerson = "";
            while ((hungryPerson=Console.ReadLine())!="End")
            {
                var person = foodBuyers.FirstOrDefault(x => x.Name == hungryPerson);
                if (person!=null)
                {
                    person.BuyFood();
                }
            }

            var foodBought = foodBuyers.Sum(x => x.Food);
            Console.WriteLine(foodBought);
        }

        private static void PrintBorn(ICollection<IBirthdate> birthdates, string yearToPrint)
        { 
            foreach (var birthdate in birthdates)
            {
                if (birthdate.Birthdate.EndsWith(yearToPrint))
                {
                    Console.WriteLine(birthdate.Birthdate);
                    
                }
            }            
        }
        private static ICollection<IBirthdate> FillBirthdates()
        {
            ICollection<IBirthdate> birthdates = new List<IBirthdate>();
            var input = "";
            while ((input=Console.ReadLine())!="End")
            {
                var tokens = input.Split();
                if (tokens[0] == "Citizen")
                {
                    var citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    birthdates.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    var pet = new Pet(tokens[1], tokens[2]);
                    birthdates.Add(pet);
                }
            }

            return birthdates;
        }

        private static void PrintFakeCitizens(IEnumerable<IId> citicentsId, string faekIds)
        {
            foreach (var citizen in citicentsId)
            {
                if (citizen.Id.EndsWith(faekIds))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
        private static ICollection<IId> InitializeIdInCity()
        {
            ICollection<IId> citicentsId = new List<IId>();
            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                if (tokens.Length == 2)
                {
                    var robot = new Robot(tokens[0], tokens[1]);
                    citicentsId.Add(robot);
                }
                else if (tokens.Length == 3)
                {
                    var citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    citicentsId.Add(citizen);
                }
            }
            return citicentsId;
        }
    }
}
