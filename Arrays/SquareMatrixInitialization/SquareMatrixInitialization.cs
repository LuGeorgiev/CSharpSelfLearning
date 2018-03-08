using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrixInitialization
{
    class SquareMatrixInitialization
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            int count = 1;
            int row = 0;
            int coll = 0;

            //while (count <= n * n)                            //type A
            //{
            //    arr[row, coll] = count;
            //    count++;
            //    row++;

            //    if (row > n - 1)
            //    {
            //        row = 0;
            //        coll++;
            //    }
            //}



            //while (count <= n * n)                            //type B
            //{
            //    arr[row, coll] = count;
            //    count++;
            //    if (coll%2==1)
            //    {
            //        row--;
            //        if (row<0)
            //        {
            //            coll++;
            //            row++;

            //        }
            //    }
            //    else
            //    {
            //        row ++;
            //        if (row>n-1)
            //        {
            //            coll++;
            //            row--;
            //        }

            //    }
            //}



            //row = n-1;                                          //type C
            //int edge=0;
            //while (count <= n * n)                            
            //{
            //    arr[row, coll] = count;
            //    row++;
            //    coll++;
            //    count++;

            //    if (row > (n - 1) || coll>(n-1))
            //    {
            //        edge++;
            //        if (edge>n-1)
            //        {
            //            row = 0;
            //            coll = edge - n+1;
            //        }
            //        else
            //        { 
            //        row = n - 1 - edge;
            //        coll = 0;
            //        }
            //    }
            //}

            string direct = "down";
            while (count <= n * n)                                              //type d
            {
                if (direct=="down"&&(row>n-1||arr[row,coll]!=0))
                {
                    coll++;
                    row--;
                    direct= "right";
                }
                if (direct == "up" && (row < 0 || arr[row, coll] != 0))
                {
                    coll--;
                    row++;
                    direct = "left";
                }
                if (direct == "right" && (coll > n-1 || arr[row, coll] != 0))
                {
                    coll--;
                    row--;
                    direct = "up";
                }
                if (direct == "left" && (coll < 0 || arr[row, coll] != 0))
                {
                    coll++;
                    row++;
                    direct = "down";
                }

                arr[row, coll] = count;
                count++;
                if (direct=="down")
                {
                    row++;
                }
                if (direct == "up")
                {
                    row--;
                }
                if (direct == "right")
                {
                    coll++;
                }
                if (direct == "left")
                {
                    coll--;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", arr[i, j]);
                }

                Console.WriteLine();

            }
             Console.WriteLine();
        
        }
    }
}
