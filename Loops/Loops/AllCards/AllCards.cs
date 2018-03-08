using System;


namespace AllCards
{
    class AllCards
    {
        static void Main()
        {
            char[] type = new char[] { '\u2663', '\u2660', '\u2665', '\u2666' };
            string [] card = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10","A", "J", "Q","K"};

            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 13; j++)
                {
                    Console.Write("{0}{1} ", type[i], card[j]);
                }
                
            }
            Console.WriteLine();

        }
    }
}
