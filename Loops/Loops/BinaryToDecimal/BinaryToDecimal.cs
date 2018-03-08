using System;


namespace BinaryToDecimal
    {
    class BinaryToDecimal
    {
        static void Main()
        {
           
            string bin = Console.ReadLine();
            int num = int.Parse(bin);
            int bit;
            int decimalNumber=0;

            for (int i=0; num!=0; i++)
            {
                bit = num % 2;
                num = num / 10;
                decimalNumber += bit * (int)Math.Pow(2, i);
            }

           
            Console.WriteLine(decimalNumber);


        }
    }
}
