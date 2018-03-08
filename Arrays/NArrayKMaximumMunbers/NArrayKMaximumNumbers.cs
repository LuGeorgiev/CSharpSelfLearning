using System;


namespace NArrayKMaximumMunbers
{
    class NArrayKMaximumNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please eneter array length");
            int n; 
            while (!((int.TryParse(Console.ReadLine(), out n)) && n>0))
            Console.WriteLine("Focus Positive integer is needed");

            int[] myArray = new int[n];
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine("Please eneter number");
                while (!int.TryParse(Console.ReadLine(), out myArray[i]))
                {
                    Console.WriteLine("Please insert iteger");
                }
            }

            Console.WriteLine("Please eneter length of CONSECUTIVE numbers in which maximum sum wil be calculated");
            int k;
            while (!((int.TryParse(Console.ReadLine(), out k)) && k > 0 && k<=n))
            Console.WriteLine("Please pay attention positive integer lower than array length is needed");
            
            int maxSum = int.MinValue;
            int tempSum = 0;

            for (int i = 0; i <= myArray.Length - k; i++)
            {
                tempSum = 0;
                for (int l=0; l < k; l++)
                {
                    tempSum += myArray[i + l];
                }

                if (tempSum>maxSum)
                {
                    maxSum = tempSum;
                }
            }

            Console.WriteLine("The maximu sum from {0} elements is {1}", k, maxSum);
        }
    }
}
