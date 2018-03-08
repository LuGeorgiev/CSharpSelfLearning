using System;


namespace IndexMultipliedBy5
{
    class IndexMultipliedBy5
    {
        static void Main()
        {
            int[] myArray = new int[20];

            for (int i = 0; i < 20; i++)
            {
                myArray[i] = i * 5;
            }

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,4}", myArray[i]);
            }
            Console.WriteLine();
        }
        
    }
}
