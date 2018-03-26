using System;
using System.Collections.Generic;
using System.Linq;

namespace MutantBunnies
{
    class RadioacticeBunnies
    {
        static void Main(string[] args)
        {
            char[,] matrix = FillMatrix();
            List<int> personPosition = FindPerson(matrix);
            var movemntCommands = Console.ReadLine();
            bool personDead = false;
            bool personWon = false;

            for (int i = 0; i < movemntCommands.Length; i++)
            {
                personPosition = MovePerson(matrix, personPosition, movemntCommands[i]);
                matrix = BunniExpansion(matrix);

                if (personPosition[personPosition.Count-1]==-1)
                {
                    //person escaped
                    personWon = true;
                    break;
                }
                else if(personPosition[personPosition.Count - 1] == -2)
                {
                    //killed by bunny TOCHECK person stepped on bunny 
                    //or bunny killed him after expansion
                    personDead = true;
                    break;
                }
            }

            if (personWon)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"won: {personPosition[personPosition.Count - 5]} {personPosition[personPosition.Count - 4]}");
            }

            if (personDead)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {personPosition[personPosition.Count - 3]} {personPosition[personPosition.Count - 2]}");
            }

        }

        private static char[,] BunniExpansion(char[,] matrix)
        {
            var maxRolLen = matrix.GetLength(0);
            var maxColLen = matrix.GetLength(1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]=='B')
                    {
                        if (i< maxRolLen-1&& matrix[i + 1, j]=='.')
                        {
                            matrix[i + 1, j] = 'C';
                        }
                        if (i >0&& matrix[i - 1, j] == '.' )
                        {
                            matrix[i - 1, j] = 'C';
                        }
                        if (j < maxColLen - 1&&matrix[i , j+1] == '.' )
                        {
                            matrix[i, j + 1] = 'C';
                        }
                        if (j >0 && matrix[i, j - 1] == '.')
                        {
                            matrix[i , j-1] = 'C';
                        }
                    }
                }                  
            }
            //PrintMatrix(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]=='C')
                    {
                        matrix[i, j] = 'B';
                    }
                }
            }
            //PrintMatrix(matrix);
            return matrix;

        }

        private static List<int> MovePerson(char[,] matrix, List<int> personPosition, char Command)
        {
            var currentRow = personPosition[ personPosition.Count - 2];
            var currentCol = personPosition[ personPosition.Count - 1];
            // TODO have to check when person was escaped or hit and when to expand bunnies
            bool onBunny = matrix[currentRow, currentCol] == 'B';
            //Check if BUNNI is on PERSON!!!!!
            if (onBunny)
            {
                // -2 position when killed
                personPosition.Add(-2);
                return personPosition;
            }

            if (Command == 'L')
            {
                //add next position LEFT
                personPosition.Add(currentRow);
                personPosition.Add(--currentCol);
            }
            else if (Command == 'R')
            {
                //add next position Right
                personPosition.Add(currentRow);
                personPosition.Add(++currentCol);
            }
            else if (Command == 'U')
            {
                //add next position UP
                personPosition.Add(--currentRow);
                personPosition.Add(currentCol);
            }
            else if (Command == 'D')
            {
                //add next position Down
                personPosition.Add(++currentRow);
                personPosition.Add(currentCol);
            }
            // Check for bunny or out of array
            var newRow = personPosition[personPosition.Count - 2];
            var newCol = personPosition[ personPosition.Count - 1];

            bool outsideArray = newRow < 0 || newRow >= matrix.GetLength(0) 
                || newCol < 0 || newCol >= matrix.GetLength(1);
            if (outsideArray)
            {
                // -1 when Person escaped
                //this last position is outside of teh buondary have to print the previous
                personPosition.Add(-1);
                return personPosition;
            }

            onBunny = matrix[newRow, newCol] == 'B';
            if (onBunny)
            {
                // -2 position when killed
                personPosition.Add(-2);
                return personPosition;
            }

            return personPosition;
        }

        private static List<int> FindPerson(char[,] matrix)
        {
            bool personFound = false;
            int row = -1;
            int col = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]=='P')
                    {
                        row = i;
                        col = j;
                        personFound = true;
                        break;
                    }
                    if (personFound)
                    {
                        break;
                    }
                }                
            }
            matrix[row, col] = '.';
            return new List<int>() { row, col };
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] FillMatrix()
        {
            var matrixDimension = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var row = matrixDimension[0];
            var col = matrixDimension[1];

            var matrix = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                var currentLine = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = currentLine[j];
                }
            }
            return matrix;
        }
    }
}
