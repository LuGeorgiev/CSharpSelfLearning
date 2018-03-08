using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynominalCalculations
{
    class PolynominalCalculations
    {
        static int[] ReadAndReversePolynom(int order)
        {
            int[] polynom = new int[order];
            Console.WriteLine("Please insert coeficient from order:{0} , to order 0",order);

            for (int i = polynom.Length-1; i >= 0; i--)
            {
                Console.Write(" X^{0} coeficient: ",i);
                polynom[i] = int.Parse(Console.ReadLine());
            }
            return polynom;
        }

        static void DisplayPolynom(int[] array)
        {
            Console.WriteLine("Final polynom is:");
            for (int i = array.Length-1;i>=0  ; i--)
            {
                Console.Write("{0}*X^{1}  ", array[i], i);
            }
            Console.WriteLine();
        }

        static int[] SumOfPolynoms(int[] shorter, int[] longer)
        {
            int[] sum= new int[longer.Length];

            for (int i = 0; i < shorter.Length; i++)
               sum[i] = shorter[i] + longer[i];

            for (int i = shorter.Length; i < longer.Length; i++)            
                sum[i] = longer[i];
            
            return sum;
        }

        static int[] MultiplyOfPolynoms(int[] first, int[] second)
        {
            int[] result = new int[first.Length + second.Length - 1];

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    result[i + j] += (first[i] * second[j]);
                }

            }
            return result;
        }

        static void Main()
        {
            Console.WriteLine("Order of first polynom");
            int n = int.Parse(Console.ReadLine());
            int[] pol1 = new int[n];
            Console.WriteLine("Order of second polynom");
            int m = int.Parse(Console.ReadLine());
            int[] pol2 = new int[m];

            pol1 = ReadAndReversePolynom(n);           
            pol2 = ReadAndReversePolynom(m);

            //int sumLength = n;                            // SUM of two polynoms
            //if (m > n)
            //    sumLength = m;
            //int[] sumResult = new int[sumLength];

            //if (pol1.Length > pol2.Length)
            //    sumResult = SumOfPolynoms(pol2, pol1);
            //else
            //    sumResult = SumOfPolynoms(pol1, pol2);
            //DisplayPolynom(sumResult);                       // END of Sum of Polynoms


            int[] multyplyResult = new int[pol1.Length + pol2.Length - 1];       // Multiply of TWO polynoms

            multyplyResult = MultiplyOfPolynoms(pol1, pol2);
            DisplayPolynom(multyplyResult);


        }
    }
}
