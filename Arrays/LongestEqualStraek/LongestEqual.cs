using System;


namespace LongestEqualStraek
{
    class LongestEqual
    {
        static void Main()
        {
            int max;
            int[] vector = new int[] { 1, 1, 1, 3, 2, 3, 1, 2, 2, 6, 6, 6 ,6 ,6 };
            int[] mask = new int[vector.Length-1];
            int bestLen = 0;
            int bestStart = 0;            
            if (vector[0] == vector[1])
            {
                mask[0] = 1;
            }

            for (int i = 1; i < mask.Length; i++)
            {
                if (vector[i]==vector[i+1])
                {
                    mask[i]=mask[i-1]+1;
                }
                else
                {
                    mask[i] = 0;
                }
            }

            max = mask[0];
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i]>max)
                {
                    max = mask[i];
                    bestStart = i - max+2;
                    bestLen = max + 1;
                }

            }

             Console.WriteLine("Biggest length of equal is: {0} and it starts from position {1}", bestLen, bestStart);

        }
    }
}
