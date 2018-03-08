using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class07102017
{
    class Program
    {
        static void Main(string[] args)
        {                   
            int n = int.Parse(Console.ReadLine());
            int pairSum = 0;
            int previourPairSum = 0;
            int bigestDiff = int.MinValue;
            bool isSumEqual = true;
            int num;

            for (int j = 0; j < 2; j++)
            {
                num = int.Parse(Console.ReadLine());
                previourPairSum += num;
            }

            for (int i = 1; i <n; i++)
            {                
                pairSum = 0;

                for (int j = 0; j < 2; j++)
                {
                    num = int.Parse(Console.ReadLine());
                    pairSum += num;
                }

                if (pairSum!=previourPairSum)
                {
                    isSumEqual = false;

                    if (bigestDiff <= Math.Abs(pairSum - previourPairSum))
                    {
                        bigestDiff = Math.Abs(pairSum - previourPairSum);
                        
                    }
                    previourPairSum = pairSum;
                }              
            }
 
            if (isSumEqual)
            {
                Console.WriteLine("Yes, value={0}", previourPairSum);
            }
            else
                Console.WriteLine("No, maxdiff={0}", bigestDiff);

        }
    }
}
        

            

