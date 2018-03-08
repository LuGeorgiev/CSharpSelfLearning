using System;


namespace ZeroSumOfFiveInt
{
    class ZeroSumOfFiveInt
    {
        static void Main()
        {
            int a = 5;
            int b = -5;
            int c = -7;
            int d = 2;
            int e = 5;

            if ((a+b+c+d+e)==0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2} {3} {4}", a,b,c,d,e );
            }
            else if((b + c + d + e)== 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2} {3}", b, c, d, e);
            }
            else if ((a + c + d + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2} {3}", a, c, d, e);
            }
            else if ((b + a + d + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2} {3}", b, a, d, e);
            }
            else if ((b + c + a + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2} {3}", b, c, a, e);
            }
            else if ((b + c + d + a) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2} {3}", b, c, d, a);
            }
            else if ((a + b + c) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", a, b, c);
            }
            else if ((a + b + d) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", a, b, d);
            }
            else if ((a + b + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", a, b, e);
            }
            else if ((a + c + d) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", a, c, d);
            }
            else if ((a + c + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", a, c, e);
            }
            else if ((a + d + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", a, d, e);
            }
            else if ((b + c + d) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", b, c, d);
            }
            else if ((c + b + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", c, b, e);
            }
            else if ((c + d + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", c, d, e);
            }
            else if ((b + d + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} {2}", b, d, e);
            }
            else if ((a + b) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", b, a);
            }
            else if ((a + c) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", a, c);
            }
            else if ((a + d) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", a, d);
            }
            else if ((a + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", a, e);
            }
            else if ((c + b) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", b, c);
            }
            else if ((d + b) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", b, d);
            }
            else if ((e + b) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", b, e);
            }
            else if ((c + d) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", c, d);
            }
            else if ((c + e) == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", e, c);
            }
            else if (a == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} ", a);
            }
            else if (b == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ",b);
            }
            else if (c == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", c);
            }
            else if (d  == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", d);
            }
            else if ( e == 0)
            {
                Console.WriteLine("Zero sum is fomed from {0} {1} ", e);
            }
            
            else
            {
                Console.WriteLine("no possibilities for zero sum combinations");
            }
        }
    }
}
