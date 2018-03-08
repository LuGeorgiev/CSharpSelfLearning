using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 34 };
            int lowEdge = 0;
            int highEdge = arr.Length-1;
            int searchIndex;
            int numberToSearch = 0;

            while (true)
            {
                searchIndex = (highEdge + lowEdge) / 2;

                if (arr[searchIndex]==numberToSearch)
                {
                    Console.WriteLine("serached number: {0} is po position: {1} !", numberToSearch,(searchIndex+1));
                    break;
                }
                else if (arr[lowEdge] == numberToSearch)
                {
                    searchIndex = lowEdge;
                    Console.WriteLine("serached number: {0} is po position: {1} !", numberToSearch, (searchIndex + 1));
                    break;

                }
                else if (arr[highEdge] == numberToSearch)
                {
                    searchIndex = highEdge;
                    Console.WriteLine("serached number: {0} is po position: {1} !", numberToSearch, (searchIndex + 1));
                    break;
                }
                else if ((lowEdge==searchIndex)||(searchIndex==highEdge))
                {
                    Console.WriteLine("There is no such number in this array!");
                    break;
                }
                else if (arr[searchIndex]>numberToSearch)
                {
                    highEdge = searchIndex;
                }
                else
                {
                    lowEdge = searchIndex;
                }

            }
        }
    }
}
