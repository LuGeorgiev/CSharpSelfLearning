using System;
using System.Linq;


    class StartUp
    {
        static void Main(string[] args)
        {
            var family = new Family();
            int familyMembersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < familyMembersCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                family.AddMember(input[0],int.Parse(input[1]));
            }
        // Problem 3. Oldest Family Member
        //var oldest = family.GetOldestMember();
        //Console.WriteLine($"{oldest.Name} {oldest.Age}");

        //Problem 4. Opinion Poll

        foreach (var person in family.OlderThan(30))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }

    }
}

