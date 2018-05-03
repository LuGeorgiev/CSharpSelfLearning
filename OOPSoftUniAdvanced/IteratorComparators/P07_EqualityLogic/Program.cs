using System;
using System.Collections.Generic;

namespace P07_EqualityLogic
{
    class Program
    {
        static void Main()
        {
            var sortedPeople = new SortedSet<Person>();
            var hashedPeople = new HashSet<Person>();
            int personCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personCount; i++)
            {
                var args = Console.ReadLine().Split();
                var name = args[0];
                var age = int.Parse(args[1]);

                Person person = new Person(name, age);

                sortedPeople.Add(person);
                hashedPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashedPeople.Count);
        }
    }
}
