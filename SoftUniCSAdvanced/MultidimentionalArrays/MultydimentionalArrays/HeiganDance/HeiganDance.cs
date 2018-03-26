using System;
using System.Collections.Generic;

namespace HeiganDance
{
    class HeiganDance
    {
        static double heiganHealth = 3000000;
        static int personealth = 18500;
        static List<int> personRowCol = new List<int>();

        static void Main()
        {
            var matrix = new int[15, 15];
            var personDmg = double.Parse(Console.ReadLine());
            personRowCol.Add(7);
            personRowCol.Add(7);

            var currentSpell = Console.ReadLine();
            while (true)
            {
                heiganHealth -= personDmg;
                if (heiganHealth<=0)
                {
                    PrintPersonVictory();
                    break;
                }
                //check second turn of Eruption

                matrix = ApplySpell(matrix, currentSpell);

                currentSpell = Console.ReadLine();
            }
        }

        private static int[,] ApplySpell(int[,] matrix, string currentSpell)
        {
            throw new NotImplementedException();
        }

        private static void PrintPersonVictory()
        {
            var playerRow = personRowCol[personRowCol.Count - 2];
            var playerCol = personRowCol[personRowCol.Count - 1];
            Console.WriteLine($"Heigan: Defeated!");
            Console.WriteLine($"Player: {personealth}");
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }
    }
}
