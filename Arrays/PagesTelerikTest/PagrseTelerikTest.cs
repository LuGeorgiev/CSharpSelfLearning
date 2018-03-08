using System;


namespace PagesTelerikTest
{
    class PagrseTelerikTest
    {
        static void Main()
        {
            int digits = int.Parse(Console.ReadLine());
            int i = 9;
            int k = 1;
            int pages = 0;

            if (digits<=9)
            {
                pages = digits;
            }
            else
            { 
                 do
                 {
                    digits = digits - i * k;
                    pages += i;
                    i =i*10;
                    k++;
                
                 }
                while (digits>i*k);

                pages = pages + digits / k;
            }

            Console.WriteLine(pages);
        }
    }
}
