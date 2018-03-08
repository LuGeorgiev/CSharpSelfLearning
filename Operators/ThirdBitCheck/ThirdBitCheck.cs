using System;


namespace ThirdBitCheck
{
    class ThirdBitCheck
    {
        static void Main()
        {
            Console.WriteLine("Enter a number to check if the third bit is 0 or 1 ");
            int digit = Convert.ToInt32(Console.ReadLine());
            int k;
            k = (digit >> 2) & 1;
            Console.WriteLine("The third digit is:"+k); 
        }
    }
}
