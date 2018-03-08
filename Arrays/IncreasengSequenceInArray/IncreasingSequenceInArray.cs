using System;

namespace IncreasengSequenceInArray
{
    class IncreasingSequenceInArray
    {
        static void Main()
        {
            int[] sequence = new int[] {1,2,3,5,10,2,5,3,4,4,6,7,2,3,1,7,8,9};

            int len = 1;
            int endposition=0;
            int bestlen=0;

            for (int i = 0; i < sequence.Length-1; i++)
            {
                if (sequence[i]<sequence[i+1])
                {
                    len++;

                    if (bestlen<len)
                    {
                        bestlen = len;
                        endposition = i + 1;
                    }
                    
                }
               else
                {
                    len = 1;
                }
            }


            Console.WriteLine("There are {0} increasing numbers starting from {1} member", bestlen ,(endposition-len+1));
        }
    }
}
