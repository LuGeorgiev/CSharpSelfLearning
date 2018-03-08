using System;


namespace SignFromMultiply
{
    class SignFromMultiply
    {
        static void Main()
        {
            bool a = false;
            bool b = false;
            bool c = false;
            if ((a ^ b) ^ c)
            {
                Console.WriteLine("The sign is POSITIVE");
            }
            else
            {
                Console.WriteLine("the Sign is NEGATIVE ");
            }
        }
    }
}
