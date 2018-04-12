using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            string matrixDimensions = Console.ReadLine();
            int[,] matrix = FillMatrix(matrixDimensions);
            

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int xE = evil[0];
                int yE = evil[1];
                DarkPowerEraseStars(matrix,xE, yE);                

                int xI = ivoS[0];
                int yI = ivoS[1];

                sum += IvoStrikesBack(matrix, xI, yI);                

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long IvoStrikesBack(int[,] matrix, int xI, int yI)
        {
            long sum = 0;
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    sum += matrix[xI, yI];
                }

                yI++;
                xI--;
            }
            return sum;
        }

        private static void DarkPowerEraseStars(int[,] matrix,int xE, int yE)
        {
            while (xE >= 0 && yE >= 0)
            {
                if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                {
                    matrix[xE, yE] = 0;
                }
                xE--;
                yE--;
            }
        }

        private static int[,] FillMatrix(string matrixDimensions)
        {
            int[] dimestions = matrixDimensions
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,]matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
            return matrix;
        }
    }
}
