using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentlyMetElement
{
    class MostFrequentlyMetElement
    {
        static void Main()
        {
            int[] arr = {3,5,6,3,2,21,4,5,4,3,2,1,1,2,3,4,2,1,6,6,6,6 };
            int count = 0;
            int tempCount = 1;
            int minPosition=0;
            int symbol=0;

            for (int i = 0; i < arr.Length; i++)
            {
                minPosition = i;

                for (int j = i+1; j < arr.Length; j++) //findindex with lowest number
                {
                    if (arr[j]<arr[minPosition])
                    {
                        minPosition = j;
                    }
                }

                if (minPosition!=i)
                {
                    arr[i] ^= arr[minPosition];
                    arr[minPosition] ^= arr[i];
                    arr[i] ^= arr[minPosition];
                }

            }



            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i-1]==arr[i])
                {
                    tempCount++;
                }

                if (arr[i - 1] != arr[i])
                {
                    tempCount = 1;
                }
                if (tempCount > count)
                {
                    count = tempCount;
                    symbol = arr[i];
                }
            }

            Console.WriteLine("most frequently met symbol is: {0}, it is met {1} times", symbol,count);


        }
    }
}
