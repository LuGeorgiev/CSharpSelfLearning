using System;


namespace Lecia
{
    class Lekcia
    {
        static void Generator(int index, int[] vector)
        {
            if (index ==-1)
            {
                Print(vector);
            }
            else
            {
                for (int i =0; i <= 1; i++)
                {
                    vector[index] = i;
                    Generator(index - 1, vector);
                }
            }
        }

        static void Print(int[] vector)
        {
            foreach (var num in vector)
            {
                Console.Write("{0} ",num);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Console.Write("n=");
            int number = int.Parse(Console.ReadLine());

            int[] vector = new int[number];
            Generator(number - 1, vector);

        }
    }
}
