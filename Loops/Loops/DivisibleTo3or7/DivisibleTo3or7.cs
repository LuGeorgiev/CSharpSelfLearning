using System;


namespace DivisibleTo3or7
{
    class DivisibleTo3or7
    {
        static void Main()
        {
            int num = 98;
           
            for (int i = 12; i < num; i++)
            {
                if ( !(i%3==0) || !(i%7==0) )
                    Console.WriteLine("{0} не се дели едновременно на 3 и 7",i );
                
            }
        }
    }
}
