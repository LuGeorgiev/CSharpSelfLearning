using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexidecimalToDecimal
{
    class HexidecimalToDecimal
    {
        static void Main(string[] args) 
        {

            string bin = Console.ReadLine();
            int number = 0;
            int bit = 0;
                        
            for (int i = 0; bin.Length != 0; i++)
            {
                
                if (bin.EndsWith("A") || bin.EndsWith("a"))
                {
                    bit = 10;
                }
                else if (bin.EndsWith("B") || bin.EndsWith("b"))
                {
                    bit = 11;
                }
                else if (bin.EndsWith("C") || bin.EndsWith("c"))
                {
                    bit = 12;
                }
                else if (bin.EndsWith("D") || bin.EndsWith("d"))
                {
                    bit = 13;
                }
                else if (bin.EndsWith("E") || bin.EndsWith("e"))
                {
                    bit = 14;
                }
                else if (bin.EndsWith("F") || bin.EndsWith("f"))
                {
                    bit = 15;
                }
                else if (bin.EndsWith("0"))
                {
                    bit = 0;
                }
                else if (bin.EndsWith("1"))
                {
                    bit = 1;
                }
                else if (bin.EndsWith("2"))
                {
                    bit = 2;
                }
                else if (bin.EndsWith("3"))
                {
                    bit = 3;
                }
                else if (bin.EndsWith("4"))
                {
                    bit = 4;
                }
                else if (bin.EndsWith("5"))
                {
                    bit = 5;
                }
                else if (bin.EndsWith("6"))
                {
                    bit = 6;
                }
                else if (bin.EndsWith("7"))
                {
                    bit = 7;
                }
                else if(bin.EndsWith("8"))
                {
                    bit = 8;
                }
                else if (bin.EndsWith("9"))
                {
                    bit = 9;
                }
                else
                {
                    Console.WriteLine("This is not viable hexidecimal number");
                    break;
                }

                number += bit * (int)Math.Pow(16, i);
                bin = bin.Remove(bin.Length - 1);
                              

            }
            Console.WriteLine(number);
            
        }
    }
}
