using System;


namespace FirstFibonachi
{
    class Program
    {
        static void Main()
        {
            decimal[] fibonachi = new decimal[100];
            fibonachi[0] = 0;
            fibonachi[1] = 1;

            Console.WriteLine("Fibonachin number {0}  is: {1}",1, fibonachi[0]);
            Console.WriteLine("Fibonachin number {0}  is: {1}",2, fibonachi[1]);

            for (int i = 2; i < 100; i++)
            {
                Console.WriteLine("Fibonachin number {0}  is: {1}", (i+1),(fibonachi[i]=fibonachi[i-1]+fibonachi[i-2]));
            }
            
             
        }
    }
}
