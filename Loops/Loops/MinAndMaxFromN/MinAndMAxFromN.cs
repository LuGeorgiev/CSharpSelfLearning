using System;

namespace MinAndMaxFromN
{
    class MinAndMAxFromN
    {
        static void Main()
        {
            int n;
            int minN;
            int maxN;
            int[] line = new int[1];

            Console.WriteLine("Молял въвведете броят на числата за сравнение");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Опитах мак");
            }

            Array.Resize(ref line, n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Моля въведете поредноото число");
                while (!int.TryParse(Console.ReadLine(), out line[i]))
                {
                    Console.WriteLine("Цяло чиско, моля");
                }

            }

            maxN = minN = line[0];

            for (int i = 0; i < n; i++)
            {
                if (line[i]<minN)
                {
                    minN = line[i];
                }

                else if (line[i]>maxN)
                {
                    maxN = line[i];
                }
            }

            Console.WriteLine("Най-Голямото число от редицата е: {0}, а най-малкото е: {1}", maxN, minN);
        }
    }
}
