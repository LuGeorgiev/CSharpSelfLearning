using System;


namespace Spiral
{
    class Spiral
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] spiral = new int[n, n];

            int counter = 1;
            int cycle = ;

            for (int i = 0, j=0; i < n-cycle; i++) //LEFT
            {
                spiral[j, i] = counter;
                counter++;

                if (i==n-cycle-1)
                {
                    for (; j < n - cycle; j++) //DOWN
                    {
                        spiral[j, i] = counter;
                        counter++;

                        if (j == n - cycle - 1)
                        {
                            for (; i >= cycle; i--)  //RIGHT
                            {
                                spiral[j, i] = counter;
                                counter++;

                                if (i == cycle)
                                {

                                    for (; j> cycle; i--) //UP
                                    {
                                        spiral[j, i] = counter;
                                        counter++;
                                        cycle ++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}",spiral[j,i]);
                    Console.WriteLine();
                }
            }

        }
    }
}
