using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{
    class MergeSortAlgorithm
    {
        static void Main()
        {
            int[] numbers = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5 };
            int[] temp = new int[numbers.Length];

            System.Console.WriteLine("Before sorting: {0}", string.Join(" ", numbers));

            MergeSort(numbers, temp, 0, numbers.Length - 1);

            System.Console.WriteLine("After sorting: {0}", string.Join(" ", numbers));
        }

        static void MergeSort(int[] array, int[] tmp, int start, int end)
        {
            // Array with 1 element
            if (start >= end) return;

            // Define a middle of the array
            int middle = start + (end - start) / 2;

            MergeSort(array, tmp, start, middle);
            MergeSort(array, tmp, middle + 1, end);

            CompareAndSort(array, tmp, start, middle, end);
        }

        static void CompareAndSort(int[] array, int[] tmp, int start, int middle, int end)
        {
            int left_tmp = start, left_arr = start, middle_arr = middle + 1;

            while (left_arr <= middle && middle_arr <= end)
            {
                if (array[left_arr] > array[middle_arr])
                {
                    tmp[left_tmp++] = array[middle_arr++];
                }
                else
                {
                    tmp[left_tmp++] = array[left_arr++];
                }
            }

            while (left_arr <= middle)
                tmp[left_tmp++] = array[left_arr++];

            while (middle_arr <= end)
                tmp[left_tmp++] = array[middle_arr++];

            for (int i = start; i <= end; i++)
                array[i] = tmp[i];
        }
    }
}
