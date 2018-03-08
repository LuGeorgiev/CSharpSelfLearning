using System;


namespace DecimalToHexidecimal
{
    class DecimalToHexidecimal
    {
        static void Main()
        {
            int num, bit;
            string hexidecimal = null;

            Console.WriteLine("enter number that will be convertet to hexidecimal");
            num = int.Parse(Console.ReadLine());

            while (num != 0)
            {
                bit = num % 16;

                if (bit > 9)
                {
                    switch (bit)
                    {
                        case 10:
                            hexidecimal = 'A' + hexidecimal;
                            break;
                        case 11:
                            hexidecimal = 'B' + hexidecimal;
                            break;
                        case 12:
                            hexidecimal = 'C' + hexidecimal;
                            break;
                        case 13:
                            hexidecimal = 'D' + hexidecimal;
                            break;
                        case 14:
                            hexidecimal = 'E' + hexidecimal;
                            break;
                        default:
                            hexidecimal = 'F' + hexidecimal;
                            break;
                    }
                }
                else
                {
                    hexidecimal = bit + hexidecimal;
                }

                
                num /= 16;

            }

            Console.WriteLine(hexidecimal);
        }
    }
}
