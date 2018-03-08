using System;


namespace TwoNumbers
{
    class TwoNumbers
    {
        static void Main()
        {
            int a = 6;
            int b = 2;

            if (a>b)
            {
                a ^= b;
                b ^= a;
                a ^= b;

            }
            Console.WriteLine(a);
        }
    }
}
