using System;
using System.Collections.Generic;
using System.Linq;


namespace NumberConversionMethods
{
    class NumConvertMethods
    {
        static int ToDecimal(char[] toConvert, int numBase)
        {
            int dec = 0;
            for (int i = 0; i < toConvert.Length; i++)
            {
                if (toConvert[i]>=65&& toConvert[i]<=70)
                {
                    dec = dec * numBase + (toConvert[i] - 'A' + 10);
                }
                else
                dec = dec* numBase + (toConvert[i]-'0');
            };
            return dec; 
        }

        static string FromDecimalToAny(int toConvert, int numericSys)
        {
            string result = "";
            string basic = "0123456789ABCDEF";

            do
            {
                result=basic[toConvert % numericSys]+result;
                toConvert /= numericSys;
            } while (toConvert>0);

            return result;
        }

        static void Main()
        {
            string deci = "12 15 8 255 3526 69";                                    // Convert from decimal to any 2-16 numeber system
            int outputBase = 16;
            int[] numbers = deci.Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(FromDecimalToAny(numbers[i], outputBase));
            }                                                                     // Convert from decimal to any 2-16 numeber system


            //string number = "11";                                               // Converts from 2-16 to decimal
            //int baseOfNumber = 8;
            //number = number.ToUpper();
            //char[] numberToConvert = number.ToCharArray();


            //Console.WriteLine(ToDecimal(numberToConvert, baseOfNumber));        // Converts from 2-16 to decimal


        }
    }
}
