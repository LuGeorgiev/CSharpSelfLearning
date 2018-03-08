using System;


namespace NODEvclid
{
    class NODEvclid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int residual;

            if (m==0&&n==0)
            {
                Console.WriteLine("GSD is 0");
            }
            else if (m==0||n==0)
            {
                if (m==0)
                {
                   Console.WriteLine("GSD is {0}", m);
                }
                else
                {
                    Console.WriteLine("GSD is {0}", n);
                }
            }
            else
            {
                if (m<n)
                {
                    m ^= n;
                    n ^= m;
                    m ^= n;
                }

                do
                {
                    residual = n % m;
                    n = m;
                    m = residual;
                }
                while (residual != 0);
                Console.WriteLine("GSD is {0}",n);

            }

        }
    }
}
