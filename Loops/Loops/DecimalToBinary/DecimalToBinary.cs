using System;


namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main()
        {
            int num, bit;
            string binary=null;

            Console.WriteLine("enter number that will be convertet to binary");
            num = int.Parse(Console.ReadLine());

            while (num!=0)
            {
                bit = num % 2;
                binary = bit+binary;
                num /= 2;

            }
            
            Console.WriteLine(binary);
        }
    }
}
