using System;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixDimension = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrixRow = matrixDimension[0];
            var matrixCol = matrixDimension[1];
            int[,] matrix = InitializeMAtrix(matrixRow, matrixCol);

            var targetInfo = Console.ReadLine();
            while (true)
            {
                if (targetInfo== "Nuke it from orbit")
                {
                    break;
                }
                matrix = DestroyCells(matrix,targetInfo);
                targetInfo = Console.ReadLine();
            }

            PrintMatrix(matrix);

        }

        private static int[,] DestroyCells(int[,] matrix, string targetInfo)
        {
            var arrayTargetInfo = targetInfo
                .Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var targetRow = arrayTargetInfo[0];
            var targetColl = arrayTargetInfo[1];
            var targetPower = arrayTargetInfo[2];

            //if (targetRow<0||targetColl<0||targetRow>=matrix.GetLength(0)||targetColl>=matrix.GetLength(1))
            //{
            //    return matrix;
            //}
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bool toDestroy =( Math.Abs(targetColl - j) <= targetPower&& targetRow==i) 
                        || (Math.Abs(targetRow - i) <= targetPower&& targetColl==j);
                    if (toDestroy)
                    {
                        matrix[i, j] = -1;
                    }
                }               
            }
            
            matrix = ShiftNotDestroyedCells(matrix);
            return matrix;           
        }

        private static int[,] ShiftNotDestroyedCells(int[,] matrix)
        {
            while (true)
            {
                bool cellNotMoved = true;
                for (int j = matrix.GetLength(1)-1; j >0 ; j--)
                {                   
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i,j]!=-1&& matrix[i, j-1] == -1)
                        {
                            matrix[i, j - 1] = matrix[i, j];
                            matrix[i, j] = -1;
                            cellNotMoved = false;
                        }
                    }                    
                }                
                if (cellNotMoved)
                {
                    break;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j]!=-1)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static int[,] InitializeMAtrix(int matrixRow, int matrixCol)
        {
            var matrix = new int[matrixRow,matrixCol];
            var counter = 0;
            for (int i = 0; i < matrixRow; i++)
            {
                for (int j = 0; j < matrixCol; j++)
                {
                    matrix[i, j] = ++counter;
                }
            }
            return matrix;
        }
    }
}
