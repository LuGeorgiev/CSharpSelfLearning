using System;


namespace FourDigits
{
    class FourDigits
    {
        static void Main()
        {
            Console.WriteLine("Please, input a four digit number - abcd");
            int num; 
            num = Convert.ToInt32(Console.ReadLine());
            int a = num / 1000;
            int b = (num % 1000) / 100;
            int c = (num % 100) / 10;
            int d = (num % 10) % 10;
            
            Console.WriteLine("The sum of all digit is:{0}",(a+b+c+d));
            Console.WriteLine("The number dcba is :"+d +c +b +a );
            Console.WriteLine("The number dcba is :" + d + a +b +c);

        }
    }
}
