using System;
using System.Text;

namespace TelericClassExplanation
{
    
    class Program
    {
        static void Main()
        {
            StringBuilder password = new StringBuilder();

            string capital = "ABCDEFGHIJKLMNOPQRSTUWXYZ";
            string small = "abcdefghijklmnopqrstuwxyz";
            string digits = "0123456789";
            string specials = "!@#%^&*(_+?><";

            Random rng = new Random();

            for (int i = 0; i < 3; i++)
            {
                password.Append(specials[rng.Next(specials.Length)]);
            }

            for (int i = 0; i < 2; i++)
            {
                int insertPosition = rng.Next(0, password.Length + 1);
                char capRnd = capital[rng.Next(0, capital.Length)];
                password.Insert(insertPosition, capRnd);
            }

            for (int i = 0; i < 2; i++)
            {
                int insertPosition = rng.Next(0, password.Length + 1);
                char digit = digits[rng.Next(0, digits.Length)];
                password.Insert(insertPosition, digit);
            }

            int length = rng.Next(0, 9);

            for (int i = 0; i < length; i++)
            {
                int insertPosition = rng.Next(0, password.Length + 1);
                char letter = small[rng.Next(0, small.Length)];
                password.Insert(insertPosition, letter);
            }

            Console.WriteLine(password);

        }
    }
}
