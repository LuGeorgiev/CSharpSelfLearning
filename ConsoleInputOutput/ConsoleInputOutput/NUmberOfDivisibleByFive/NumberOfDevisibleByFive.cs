using System;


namespace NUmberOfDivisibleByFive
{
    class NumberOfDevisibleByFive
    {
        static void Main()
        {
            Console.WriteLine("Please insert first integer");
            int limesA = int.Parse(Console.ReadLine());

            Console.WriteLine("Please insert second integer");
            int limesB = int.Parse(Console.ReadLine());
            uint counter = 0;
            if (limesA>limesB)
            {
                limesA ^= limesB;
                limesB ^= limesA;
                limesA ^= limesB;
                            
            }


            for (int i = limesA; i < limesB; i++)
            {

                if (i % 5 == 0)
                {
                    counter++;
                }
            }
            

            Console.WriteLine("There are {0} numbers that are devisible by 5 between numbers you have just enetered.", counter);

        }
    }
}
