using System;
using System.Linq;

namespace _2by2SquareInMatrix
{
    class SquareInMatrix
    {
        static void Main(string[] args)
        {
            var matrixDiemnsions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var row = matrixDiemnsions[0];
            var col = matrixDiemnsions[1];
            var matrix = new string[row, col];
            var squareCounter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] line = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {                
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    string toCompare = matrix[i, j];
                    if (toCompare == matrix[i, j+1]&& toCompare == matrix[i+1,j]&& toCompare == matrix[i+1, j+1])
                    {
                        squareCounter++;
                    }                    
                }
            }
            Console.WriteLine(squareCounter);
        }
    }
}
