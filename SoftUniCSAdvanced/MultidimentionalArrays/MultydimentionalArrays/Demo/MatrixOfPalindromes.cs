using System;
using System.Linq;

namespace Demo
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            string[,] matrix = new string[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = alphabet[i].ToString() + alphabet[i+j].ToString() + alphabet[i].ToString();
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
