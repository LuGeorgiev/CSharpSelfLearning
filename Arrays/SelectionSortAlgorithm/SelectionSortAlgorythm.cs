using System;


namespace SelectionSortAlgorithm
{
    class SelectionSortAlgorythm
    {
        static void Main()
        {
            int[] array = { 3, 5, 9, 2, 5, 9, 19, 5, 78, 3 };
            int[] reverse = new int[array.Length];

            for (int i = 0; i < array.Length-1; i++)
            {
                int minPosition = i;

                for (int k = i; k < array.Length; k++)
                {
                    if (array[minPosition]>array[k])
                    {
                        minPosition = k;
                    }                    
                }
                if (array[minPosition] != array[i])
                {
                    array[minPosition] ^= array[i];
                    array[i] ^= array[minPosition];
                    array[minPosition] ^= array[i];
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}  ",array[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                reverse[i] = array[array.Length - i - 1];
                Console.Write("{0}  ", reverse[i]);
            }
            Console.WriteLine();

        }
    }
}
