using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitMatrixTelerik
{
    class ShiftMatrixTelerik
    {
        static int[,] MatrixFill(int r, int c)
        {
            int[,] matrix = new int[r, c];

            matrix[r - 1, 0] = 1;
            for (int i = r-2; i >= 0; i--)
            {
                matrix[i, 0] = matrix[i + 1, 0]*2;
            }

            for (int i = 0; i < r; i++)
            {                
                for (int j = 1; j < c; j++)
                {
                    matrix[i, j] = matrix[i , j-1] * 2;
                }                
            }   
            
            return matrix;
        }

        static int[,] MovingCoordinates(string mov, int row, int col)
        {
            string[] steps = mov.Split(' ');
            int[] stepArray = new int[steps.Length];
            for (int i = 0; i < steps.Length; i++)
                stepArray[i] = int.Parse(steps[i]);
            int coef = row;
            if (col > row)
                coef = col;           

            int[,] moves = new int[stepArray.Length + 1, 2];
            moves[0, 0] = row-1;                                //initial row
            moves[0, 1] = 0;                                    //initial col
            for (int i = 1; i < moves.GetLength(0); i++)
            {
                moves[i, 0] = stepArray[i - 1] / coef;          //next row
                moves[i, 1] = stepArray[i - 1] % coef;          //next col
            }

            return moves;
        }

        static int SumCalculation(int[,] matrix, int[,] trace)
        {
            int sum = 0;
            for (int i = 0; i < trace.GetLength(0)-1; i++)
            {
                int startRow = trace[i, 0];
                int startCol = trace[i, 1];
                int endRow = trace[i + 1, 0];
                int endCol = trace[i + 1, 1];
                int step = 0;

                if (startCol < endCol)
                { 
                    for (int j = startCol; j <= endCol; j ++)
                    {
                        sum += matrix[startRow, j];
                        matrix[startRow, j] = 0;
                    }
                }
                else
                {
                    for (int j = startCol; j >= endCol; j--)
                    {
                        sum += matrix[startRow, j];
                        matrix[startRow, j] = 0;
                    }
                }
                

                if (startRow < endRow)
                {
                    for (int j = startRow; j <= endRow; j++)
                    {
                        sum += matrix[j, endCol];
                        matrix[j, endCol] = 0;
                    }
                }
                else
                { 
                     for (int j = startRow; j >= endRow; j --)
                     {
                         sum += matrix[j, endCol];
                         matrix[j, endCol] = 0;
                     }
                }
            }

            return sum;
        }

        static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());
            string code = Console.ReadLine();

            int result = 0;
            int[,] matrix = new int[row, col];
            int[,] nextMove = new int[moves+1,2];

            matrix = MatrixFill(row, col);
            nextMove = MovingCoordinates(code, row, col);
            result = SumCalculation(matrix,nextMove);
            Console.WriteLine(result);
            
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write("{0,4}",nextMove[i, j]);
            //    }
            //    Console.WriteLine();
            //}


        }
    }
}
