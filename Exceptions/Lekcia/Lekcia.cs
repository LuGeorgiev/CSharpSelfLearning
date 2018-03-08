using System;


namespace Lekcia
{
     
    class Lekcia
    {

        static int Parse(string number)
        {
            var result = 0;
            foreach (char symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    throw new FormatException();
                }
                result = result * 10 + (symbol - '0');
            }
            return result;
        }

        static void RadUserNUmber()
        {
            try
            {
                int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Bad format");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Too big");
            }
            finally
            {
                Console.WriteLine("Dong some cleanup");
            }

        }

        static void Main()
        {
            RadUserNUmber();
            
        }
    }
}
