using System;


namespace BinaryToDecimalHorner
{
    class Program
    {
        static void Main()                                  //BinaryToDecimalHorner
        {
            string binary = Console.ReadLine();
            int result = 1;
            int[] binaryBits = new int[binary.Length];
            int length = binary.Length;

            for (int i=length-1; i>= 0; i--)
            {
                if (binary.EndsWith("1"))
                {
                    binaryBits[i] = 1;
                }
                else
                {
                    binaryBits[i] = 0;
                }

                binary = binary.Remove(binary.Length - 1);
            }

            result = binaryBits[0] * 2 + binaryBits[1];

            for (int i = 1; i < length-1; i++)
            {
                result = result * 2 + binaryBits[i + 1];
            }
            Console.WriteLine(result);
        }
    }
}
