using System;
using System.Collections.Generic;

namespace P06_StrategyPattern
{
    public class StartSorting
    {
        static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var nameSort = new SortedSet<Person>();
            var ageSort = new SortedSet<Person>(new PersonAgeComparer());

            for (int i = 0; i < people; i++)
            {
                var personInput = Console.ReadLine().Split();
                var name = personInput[0];
                var age = int.Parse(personInput[1]);
                var person = new Person(name, age);

                nameSort.Add(person);
                ageSort.Add(person);
            }
            foreach (var person in nameSort)
            {
                Console.WriteLine(person);
            }
            foreach (var person in ageSort)
            {
                Console.WriteLine(person);
            }
            

        }
    }
}
