using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToHexidecimal
{
    class BinaryToHexidecimal
    {
        static string FromDecimalToAny(string toConvert)
        {
            string result = "";
            int counter = 0;
            string basic = "0123456789ABCDEF";
            char[] bit = toConvert.ToCharArray();

            for (int i = 0; i < 4; i++)
            {
                counter = counter * 2 + (bit[i] - '0');
            }
            result = result+basic[counter];
            return result;
        }

        static void Main()
        {
            string binary = "1011111";
            int fill = 4-(binary.Length % 4);
            string hexDigit = "";
            string output = "";

            while (fill != 0)
            {
                binary = "0" + binary;
                fill--;
            }

            for (int i = binary.Length-1; i > 0; i=i-4)
            {
                for (int j = i; j > i-4; j--)
                {
                    output = binary[j] + output;
                }
                hexDigit= FromDecimalToAny(output)+ hexDigit;
                output = "";
            }

            Console.WriteLine(hexDigit);

        }
    }
}
