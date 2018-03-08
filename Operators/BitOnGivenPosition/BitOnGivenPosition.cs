using System;


namespace BitOnGivenPosition
{
    class BitOnGivenPosition
    {
        static void Main()
        {
            Console.WriteLine("Please, input an integer number");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, choose the bit on which position to check. betwween 1 and 32 ");
            int p = Convert.ToInt32(Console.ReadLine());
                        
            Console.WriteLine(Convert.ToString(n,2));

            n = (n >> p) & 1;

            Console.WriteLine("The bit on this position is:" +n);

        }
    }
}
