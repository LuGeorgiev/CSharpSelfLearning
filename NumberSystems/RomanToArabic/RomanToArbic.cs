using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToArabic
{
    class RomanToArbic
    {
        static void Main(string[] args)
        {
            string romanNumb = Console.ReadLine().ToUpper();
            char[] bits = new char[romanNumb.Length];
            bits = romanNumb.ToCharArray();
            int result = 0;

            for (int i = 0; i < bits.Length-1; i++)
            {
                if (bits[i]=='M')
                {
                    result += 1000;
                }
                else if (bits[i] == 'D')
                {
                    if (bits[i+1]=='M')                    
                        result -= 500;
                    else
                        result += 500;
                }
                else if (bits[i] == 'C')
                {
                    if (bits[i + 1] == 'D'|| bits[i + 1] == 'M')
                        result -= 100;
                    else
                        result += 100;
                }
                else if(bits[i] == 'L')
                {
                    if (bits[i + 1] == 'D' || bits[i + 1] == 'M'|| bits[i + 1]=='C')
                        result -= 50;
                    else
                        result += 50;
                }
                else if(bits[i] == 'X')
                {
                    if (bits[i + 1] == 'D' || bits[i + 1] == 'M' || bits[i + 1] == 'C' || bits[i + 1] == 'L')
                        result -= 10;
                    else
                        result += 10;
                }
                else if(bits[i] == 'V')
                {
                    if (bits[i + 1] == 'D' || bits[i + 1] == 'M' || bits[i + 1] == 'C' || bits[i + 1] == 'L' || bits[i + 1] == 'X')
                        result -= 5;
                    else
                        result += 5;
                }
                else if(bits[i] == 'I')
                {
                    if (bits[i + 1] == 'D' || bits[i + 1] == 'M' || bits[i + 1] == 'C' || bits[i + 1] == 'L' || bits[i + 1] == 'X' || bits[i + 1] == 'V')
                        result -= 1;
                    else
                        result += 1;
                }

            }

            if (bits[bits.Length-1] == 'M')            
                result += 1000;
            
            else if (bits[bits.Length - 1] == 'D')            
                result += 500;
            
            else if (bits[bits.Length - 1] == 'C')            
                result += 100;
            
            else if (bits[bits.Length - 1] == 'L')            
                result += 50;
            
            else if (bits[bits.Length - 1] == 'X')            
                result += 10;
            
            else if (bits[bits.Length - 1] == 'V')            
                result += 5;
            
            else if (bits[bits.Length - 1] == 'I')            
                result += 1;
            

            Console.WriteLine(result);
        }
    }
}
