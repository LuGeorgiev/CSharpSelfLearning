using System;


namespace ConsecutiveMaximumSum
{
    class Program
    {
        static void Main()
        {
            int[] arr = {2,3,-6,-1,2,-1,6,4,-8,8};
            int maxSum = int.MinValue;
            int tempSum = 0;

            for (int l = 1; l <= arr.Length; l++) // quantity of numbers that form the sum
            {
                for (int m = 0; m <= arr.Length-l; m++) // Sum first index
                {
                    tempSum = 0;

                    for (int n = m; n < m+l; n++)  //calculate sum
                    {
                        tempSum += arr[n];
                    }

                    if (tempSum>maxSum)
                    {
                        maxSum = tempSum;
                    }
                }

            }

            Console.WriteLine(maxSum);
        }
    }
}
