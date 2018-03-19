using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            //var matrix = new int[matrixSize, matrixSize];
            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                var inputRow = Console.ReadLine()
                    .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    //matrix[i, j] = inputRow[j];
                    if (i==j)
                    {
                        sumPrimaryDiagonal += inputRow[j];
                    }
                    if (i+j==matrixSize-1)
                    {
                        sumSecondaryDiagonal+= inputRow[j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumPrimaryDiagonal-sumSecondaryDiagonal));
        }
    }
}
