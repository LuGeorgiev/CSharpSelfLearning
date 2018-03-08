using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3x3MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int coll = int.Parse(Console.ReadLine());
            int maxSum = 0;
            int tempSum = 0;
            int[,] arr = new int[row, coll];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < coll; j++)
                {
                    arr[i, j] = int.Parse(Console.ReadLine());
                }

            }

            for (int i = 0; i < row-2; i++)
            {
                tempSum = 0;
                for (int j = 0; j < coll-2; j++)
                {
                    tempSum = arr[i, j] + arr[i + 1, j] + arr[i + 2, j] + arr[i, j + 1] + arr[i + 1, j + 1] + arr[i + 2, j + 1]
                        + arr[i, j + 2] + arr[i + 1, j + 2] + arr[i + 2, j + 2];
                }
                if (tempSum>maxSum)
                {
                    maxSum = tempSum;
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}
