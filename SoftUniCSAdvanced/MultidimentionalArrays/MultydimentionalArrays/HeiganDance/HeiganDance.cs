using System;
using System.Collections.Generic;
using System.Linq;

namespace HeiganDance
{
    class HeiganDance
    {
        static double heiganHealth = 3000000;
        static int personHealth = 18500;
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
                matrix = ApplyEruptionSecondTime(matrix);
                if (personHealth <= 0)
                {
                    PrintHeganVictory(currentSpell);
                    break;
                }

                heiganHealth -= personDmg;
                if (heiganHealth<=0)
                {
                    PrintPersonVictory();
                    break;
                }


                matrix = ApplySpell(matrix, currentSpell);
                MovePerson(matrix);
                if (personHealth<=0)
                {
                    PrintHeganVictory(currentSpell);
                    break;
                }

                currentSpell = Console.ReadLine();
            }
        }

        private static int[,] ApplyEruptionSecondTime(int[,] matrix)
        {
            var playerRow = personRowCol[personRowCol.Count - 2];
            var playerCol = personRowCol[personRowCol.Count - 1];
            if (matrix[playerRow,playerCol]==70)
            {
                personHealth -= 3500;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
            return matrix;
        }

        private static void PrintHeganVictory(string finalSpell)
        {
            var playerRow = personRowCol[personRowCol.Count - 2];
            var playerCol = personRowCol[personRowCol.Count - 1];
            var coupDeGrace = finalSpell.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault()
                .Trim();
            if (coupDeGrace!= "Eruption")
            {
                coupDeGrace = "Plague Cloud";
            }
            Console.WriteLine($"Heigan: {heiganHealth:F2}");
            Console.WriteLine($"Player: Killed by {coupDeGrace}");
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static void MovePerson(int[,] matrix)
        {
            var personRow = personRowCol[personRowCol.Count - 2];
            var personCol = personRowCol[personRowCol.Count - 1];
            // implenet movement TODO
            if (matrix[personRow,personCol]!=0)
            {
                var canMoveUp = personRow - 1 >= 0 && matrix[personRow - 1, personCol] == 0;
                var canMoveRight = personCol + 1 <= 14 && matrix[personRow, personCol+1] == 0;
                var canMoveDown = personRow + 1 <= 14 && matrix[personRow + 1, personCol] == 0;
                var canMoveLeft = personCol - 1 >= 0 && matrix[personRow , personCol-1] == 0;

                if (canMoveUp)
                {
                    personRowCol.Add(personRow - 1);
                    personRowCol.Add(personCol);
                }
                else if (canMoveRight)
                {
                    personRowCol.Add(personRow);
                    personRowCol.Add(personCol+1);
                }
                else if (canMoveDown)
                {
                    personRowCol.Add(personRow + 1);
                    personRowCol.Add(personCol);
                }
                else if (canMoveLeft)
                {
                    personRowCol.Add(personRow);
                    personRowCol.Add(personCol-1);
                }
                else
                {
                    if (matrix[personRow,personCol]==70)
                    {
                        personHealth -= 3500;
                    }
                    else
                    {
                        personHealth -= 6000;
                    }                    
                }
            }            
        }

        private static int[,] ApplySpell(int[,] matrix, string currentSpell)
        {
            var spellDmg = 0;
            var spellInfo = currentSpell
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var spellType = spellInfo[0];
            var spellRow = int.Parse(spellInfo[1]);
            var spellCol = int.Parse(spellInfo[2]);
            if (spellType== "Eruption")
            {
                spellDmg = 60;
            }
            else
            {
                spellDmg = 70;
            }

            var dmgStartRow = spellRow - 1;
            var dmgEndRow = spellRow + 1;
            var dmgStartCol = spellCol - 1;
            var dmgEndCol = spellCol + 1;

            for (int i = dmgStartRow; i <= dmgEndRow; i++)
            {
                for (int j = dmgStartCol; j <= dmgEndCol; j++)
                {
                    if (i>=0 && i<=14 && j>=0 && j<=14)
                    {
                        matrix[i, j] = spellDmg;
                    }
                }
            }
            return matrix;
        }

        private static void PrintPersonVictory()
        {
            var playerRow = personRowCol[personRowCol.Count - 2];
            var playerCol = personRowCol[personRowCol.Count - 1];
            Console.WriteLine($"Heigan: Defeated!");
            Console.WriteLine($"Player: {personHealth}");
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }
    }
}
