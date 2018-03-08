using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayComparoson
{
    class ArrayComparison
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter first array length");
            int arrayALength = int.Parse(Console.ReadLine());

            Console.WriteLine("enter second array length");
            int arrayBLength = int.Parse(Console.ReadLine());

            bool equal = false;

            if (arrayALength != arrayBLength)
            {
                Console.WriteLine("both Arrayes are not equal");
            }
            else
            {
                string[] arrA = new string[arrayALength];
                string[] arrB = new string[arrayBLength];

                for (int i = 0; i < arrayALength; i++)
                {
                    Console.WriteLine("enter array A member");
                    arrA[i] = Console.ReadLine();
                }

                for (int i = 0; i < arrayBLength; i++)
                {
                    Console.WriteLine("enter array B member");
                    arrB[i] = Console.ReadLine();
                }

                for (int i = 0; i < arrayBLength; i++)
                {
                    if (arrA[i] != arrB[i])
                    {
                        Console.WriteLine("both arrayes are not equal");
                        equal = false;
                        break;
                    }
                    else
                    {
                        equal = true;
                    }
                }
                if (equal)
                {
                    Console.WriteLine("arayyes are equal");
                }
            }
        }
    }
}
