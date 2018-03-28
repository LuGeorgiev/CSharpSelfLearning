using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatrixRorartion
{
    class MatrixRotation
    {
        static void Main(string[] args)
        {
            var pattern = @"Rotate\((\d+)\)";
            var rgx = new Regex(pattern);
            var matchRotation = rgx.Match(Console.ReadLine());
            var degree = int.Parse(matchRotation.Groups[1].Value) % 360;

            var line = Console.ReadLine();
            var allLines = new List<string>();
            var maxLineLength = 0;
            while (true)
            {
                if (line== "END")
                {
                    break;
                }
                if (line.Length> maxLineLength)
                {
                    maxLineLength = line.Length;
                }
                allLines.Add(line);

                line = Console.ReadLine();
            }

            var matrixToRotate = InitializeMatrix(allLines, maxLineLength);
            if (degree == 0)
            {
                Print(matrixToRotate);
            }
            else if (degree == 90)
            {
                PrintNinety(matrixToRotate);
            }
            else if (degree == 180)
            {
                PrintOneHundredEighty(matrixToRotate);
            }
            else if (degree == 270)
            {
                PrintTwoHundredSeventy(matrixToRotate);
            }
        }

        private static void PrintTwoHundredSeventy(char[,] matrix)
        {
            //not finished
            for (int j = matrix.GetLength(1)-1; j >=0; j--)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintOneHundredEighty(char[,] matrix)
        {            
            for (int i = matrix.GetLength(0)-1; i >=0; i--)
            {
                for (int j = matrix.GetLength(1)-1; j >=0 ; j--)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintNinety(char[,] matrix)
        {            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = matrix.GetLength(0)-1; i >=0; i--)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Print(char[,] matrix)
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

        private static char[,] InitializeMatrix(List<string> allLines, int maxLineLength)
        {
            var matrixRow = allLines.Count;
            var matrixCol = maxLineLength;
            var matrix = new char[matrixRow, matrixCol];

            for (int i = 0; i < matrixRow; i++)
            {
                for (int j = 0; j < matrixCol; j++)
                {
                    if (j<allLines[i].Length)
                    {
                        matrix[i, j] = allLines[i][j];
                    }
                    else
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }

            return matrix;
        }
    }
}
