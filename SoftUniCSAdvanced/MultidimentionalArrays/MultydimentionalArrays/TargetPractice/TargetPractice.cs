using System;
using System.Linq;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            var matrixDiemnsions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var row = matrixDiemnsions[0];
            var col = matrixDiemnsions[1];
            char[,] matrix = new char[row, col];
            var matrixFiller = Console.ReadLine();

            matrix = ToFillMatrix(matrix, matrixFiller);

            var gunShotInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var shotRow = gunShotInfo[0];
            var shotCol = gunShotInfo[1];
            var shotPower = gunShotInfo[2];

            matrix = ShottedSnake(matrix, shotRow, shotCol, shotPower);
            matrix = SymbolsFall(matrix);
            //print
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
            
        }

        private static char[,] SymbolsFall(char[,] matrix)
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);
            bool shifPerformed = false;
            while (true)
            {
                shifPerformed = false;
                for (int i = 0; i < row-1; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (matrix[i,j]!=' '&& matrix[i+1,j]==' ')
                        {
                            matrix[i + 1, j] = matrix[i, j];
                            matrix[i, j]=' ';
                            shifPerformed = true;
                        }
                    }
                }
                if (!shifPerformed)
                {
                    break;
                }
            }
            return matrix;
        }

        private static char[,] ShottedSnake(char[,] matrix, int shotRow, int shotCol, int shotPower)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var distanceToShot = Math.Abs(shotRow - i) + Math.Abs(shotCol - j);
                    if (distanceToShot<=shotPower)
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
            return matrix;
        }

        private static char[,] ToFillMatrix(char[,] matrix, string matrixFiller)
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);
            var matrixToFill = new char[row, col];
            var rightToLeft = true;
            var fillerCounter = 0;

            for (int i = row-1; i >= 0; i--)
            {
                if (rightToLeft)
                {
                    for (int j = col-1; j >=0; j--)
                    {
                        matrixToFill[i, j] = matrixFiller[fillerCounter];
                        fillerCounter++;
                        if (fillerCounter>=matrixFiller.Length)
                        {
                            fillerCounter = 0;
                        }
                    }
                    rightToLeft = false;
                }
                else
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrixToFill[i, j] = matrixFiller[fillerCounter];
                        fillerCounter++;
                        if (fillerCounter >= matrixFiller.Length)
                        {
                            fillerCounter = 0;
                        }
                    }
                    rightToLeft = true;
                }
            }
            return matrixToFill;
        }
    }
}
