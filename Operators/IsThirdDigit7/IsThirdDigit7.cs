using System;


namespace IsThirdDigit7
{
    class IsThirdDigit7
    {
        static void Main()
        {
            Console.WriteLine("enter a number to check if the third digit from right is 7 ");
            int digit=Convert.ToInt32(Console.ReadLine());
            int k;
            k = digit / 100;
            k = k % 10;
            Console.WriteLine(k==7?"Yes,the digit is 7":"No, the digit is not 7");

            
        }
    }
}
