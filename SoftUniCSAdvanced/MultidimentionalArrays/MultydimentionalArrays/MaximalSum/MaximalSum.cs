using System;
using System.Linq;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            var matrixDiemnsions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var row = matrixDiemnsions[0];
            var col = matrixDiemnsions[1];
            var matrix = new int[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] line = Console.ReadLine()
                    .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            var maxSum = int.MinValue;
            var maxColStart = 0;
            var maxRolStart = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var currentSum = matrix[i, j] + matrix[i, j+1] + matrix[i, j+2] + matrix[i+1, j] 
                        + matrix[i+1, j+1] + matrix[i+1, j+2] + matrix[i+2, j] + matrix[i+2, j+1] + matrix[i + 2, j+2];
                    if (currentSum> maxSum)
                    {
                        maxSum = currentSum;
                        maxRolStart = i;
                        maxColStart = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxRolStart; i < maxRolStart+3; i++)
            {
                for (int j = maxColStart; j < maxColStart+3; j++)
                {
                    Console.Write(matrix[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
