using System;


namespace NameOfTheDigits
{
    class NameOfTheDigits
    {
        static void Main()
        {
            int digit = 90;

            switch (digit)
            {
                case 1: Console.WriteLine("ONE");break;
                case 2: Console.WriteLine("TWO");break;
                case 3: Console.WriteLine("THREE"); break;
                case 4: Console.WriteLine("FOUR"); break;
                case 5: Console.WriteLine("FIVE"); break;
                case 6: Console.WriteLine("SIX"); break;
                case 7: Console.WriteLine("SEVEN"); break;
                case 8: Console.WriteLine("EIGHT"); break;
                case 9: Console.WriteLine("NINE"); break;
                case 0: Console.WriteLine("TEN"); break;
                default:
                    Console.WriteLine("please eneter A digit");
                    break;
            }

        }
    }
}
