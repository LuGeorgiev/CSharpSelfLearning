using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMethods
{
    class MatrixMetods
    {
        static void MatrixPrint(int[,] matrix)      //Matrix PRINT
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}",matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        static int[,] MatrixInput(int n, int m)    //Matrix READ
        {
            int[,] arr = new int[n, m];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return arr;
        }

        static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            int coll = int.Parse(Console.ReadLine());

            MatrixPrint(MatrixInput(row,coll));
        }
    }
}
