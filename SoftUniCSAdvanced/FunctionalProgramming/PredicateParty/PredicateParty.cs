using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var partyPeople = Console.ReadLine().Split().ToList();
            var input = "";
            while ((input=Console.ReadLine())!= "Party!")
            {
                var commands = input.Split();

                if (commands[1]== "StartsWith")
                {
                    ApplyOnEverybody(commands[0], partyPeople, x => x.StartsWith(commands[2]));
                }
                else if (commands[1] == "EndsWith")
                {
                    ApplyOnEverybody(commands[0], partyPeople, x => x.EndsWith(commands[2]));
                }
                else if (commands[1] == "Length")
                {
                    ApplyOnEverybody(commands[0], partyPeople, x => x.Length==int.Parse(commands[2]));
                }

            }

            if (partyPeople.Count>0)
            {
                Console.WriteLine(String.Join(", ",partyPeople)+ " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void ApplyOnEverybody(string comand, List<string> partyPeople, Func<string, bool> func)
        {
            for (int i = partyPeople.Count-1; i >=0; i--)
            {
                if (func(partyPeople[i])&&comand== "Remove")
                {
                    partyPeople.RemoveAt(i);
                }
                else if (func(partyPeople[i]) && comand == "Double")
                {
                    partyPeople.Insert(i,partyPeople[i]);
                }

            }
        }
    }
}
