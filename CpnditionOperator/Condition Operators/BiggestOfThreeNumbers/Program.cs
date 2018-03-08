using System;


namespace BiggestOfThreeNumbers
{
    class Program
    {
        static void Main()
        {
            int a = 3;
            int b = -9;
            int c = -244;
            int maxValue;

            if ((a<c)&&(b<c))
            {
                maxValue = c;
                Console.WriteLine(maxValue);
            }
            else if((a<b)&&(c<b))
            {
                maxValue = b;
                Console.WriteLine(maxValue);
            }
            else
	        {
                maxValue = a;
                Console.WriteLine(maxValue);
            }
               
        }
    }
}
