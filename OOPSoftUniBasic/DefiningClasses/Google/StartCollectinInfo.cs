using System;
using System.Collections.Generic;

namespace Google
{
    public class StartCollectinInfo
    {
        // Currently 80/100
        // To check is soem of the DECIMAL field is not in output format
        // HAve to re-work decimal fields NOT to be strings
        static void Main(string[] args)
        {
            var input = "";
            var peopleData = new Dictionary<string, Person>();

            while ((input=Console.ReadLine())!="End")
            {
                var inputData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = inputData[0];
                var action = inputData[1];
                if (!peopleData.ContainsKey(name))
                {
                    peopleData.Add(name, new Person());
                }

                if (action == "company")
                {
                    peopleData[name].SetCompany(inputData[2], inputData[3], inputData[4]);
                }
                else if (action == "car")
                {
                    peopleData[name].SetCar(inputData[2], inputData[3]);
                }
                else if (action == "pokemon")
                {
                    peopleData[name].AddPokemon(new Pokemon(inputData[2], inputData[3]));
                }
                else if (action == "parents")
                {
                    peopleData[name].AddParent(new Parent(inputData[2], inputData[3]));
                }
                else if (action == "children")
                {
                    peopleData[name].AddChild(new Child(inputData[2], inputData[3]));
                }
            }

            var personToPrint = Console.ReadLine();
            Console.WriteLine(personToPrint);
            Console.WriteLine(peopleData[personToPrint].ToString());
        }
    }
}
