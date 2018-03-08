using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1multK1
{
    class N1multK1
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int j = 0;

                if (i == 0 || i == (n - 1))
                {
                    for (j = 0; j < n; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }

                else
                {

                    for (j = 0; j < n; j++)
                    {
                        if (j == 0 || j == (n - 1))
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
