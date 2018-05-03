using System;
using System.Collections.Generic;

namespace P05_ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            var input = "";
            while ((input=Console.ReadLine())!="END")
            {
                var personData = input.Split();
                var name = personData[0];
                var age = int.Parse( personData[1]);
                var town = personData[2];

                people.Add(new Person(name, age, town));

            }
            var personindex = int.Parse(Console.ReadLine());
            var personToCompare = people[personindex - 1];
            SummedUpComparrison(personToCompare,people);
        }

        private static void SummedUpComparrison(IPerson personToCompare, IEnumerable<Person> people)
        {
            int equalPerson = 0;
            int allPeople = 0;

            foreach (var person in people)
            {
                allPeople++;
                if (personToCompare.CompareTo(person)==0)
                {
                    equalPerson++;
                }
            }

            if (equalPerson==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPerson} {allPeople-equalPerson} {allPeople}");
            }
        }
    }
}
