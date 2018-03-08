using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinacii
{
    class Kobinacii
    {
        static void Generator(int index, int[] vector,int start)
        {
            if (index == -1)
            {
                Print(vector);
            }
            else
            {
                for (int i = start; i <= names.Length-1; i++)
                {
                    vector[index] = i;
                    Generator(index - 1, vector,i+1);
                }
            }
        }

        static void Print(int[] vector)
        {
            foreach (var i in vector)
            {
                Console.Write("{0,-6} ", names[i]);
            }
            Console.WriteLine();
        }

        static string[] names = { "Ivan", "Pesho", "Mimi", "Penka", "Kiro" };
        static int n = 2;

        static void Main(string[] args)
        {
            int[] vector = new int[n];
            
            Generator(n - 1, vector, 0);
        }
    }
}
