using System;


namespace SortThreeNumbers
{
    class Program
    {
        static void Main()
        {
            int a = 4;
            int b = 1;
            int c = 22;
            int temp;
            if (a<b)
            {
                if (b<c)
                {
                    a ^= c;
                    c ^= a;
                    a ^= c;
                }
                else if(a<c)
                {
                    temp = a;
                    a = b;
                    b = c;
                    c = temp;

                }
                else
                {
                    a ^= b;
                    b ^= a;
                    a ^= b;
                }

            }
            else
            {
                if(b>c)
                {

                }
                else if(a>c)
                {
                    b ^= c;
                    c ^= b;
                    b ^= c;
                }
                else
                {
                    temp = a;
                    a = c;
                    c = b;
                    b = temp;
                }
            }

            Console.WriteLine(a+" "+b+" "+c);
        }
    }
}
