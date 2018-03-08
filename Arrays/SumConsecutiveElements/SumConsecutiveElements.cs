using System;


namespace SumConsecutiveElements
{
    class SumConsecutiveElements
    {
        static void Main()
        {
            int sum = 4;
            int[] vector = { 1, 3, 2,};

            int tempSum = 0;
            int index = 0;
            int numberOfElements= 0;

            for (int i = 1; i <= vector.Length; i++)  // broi cifri
            {
                for (int k = 0; k <= vector.Length-i; k++) // nachalen index
                {
                    tempSum = 0;
                    for (int j = k; j < k+i; j++) // suma na elementite
                    {
                        tempSum += vector[j];

                        if (tempSum==sum)
                        {
                            index = k;
                            numberOfElements = i;
                            break;
                        }
                    }
                    if (numberOfElements!=0)
                    {
                        break;
                    }

                }
                if(numberOfElements != 0)
                {
                    break;
                }

            }

            if (numberOfElements == 0)
            {
                Console.WriteLine("there is no number sequence that can form this sum");
            }
            else
            {
                Console.WriteLine("vector is:");
                for (int i = index; i < (index + numberOfElements); i++)
                {
                    Console.Write("{0} ",vector[i]);
                }
            }
        }
    }
}
