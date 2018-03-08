using System;


namespace IntStrOrDouble
{
    class IntStrOrDouble
    {
        static void Main()
        {
            int i;
            double d;
            string s;
            int choice;
            Console.WriteLine("Please choose 1 for integer, 2 for double and 3 forstring");

            while (!(int.TryParse(Console.ReadLine(),out choice) && choice > 0 && choice < 4))
            {
                Console.WriteLine("Please, focus and choose 1 for integer, 2 for double and 3 forstring");
            }

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("please enter integer number");
                        while (!int.TryParse(Console.ReadLine(), out i))
                        {
                            Console.WriteLine("Please, focus and enter integer");
                        }
                            
                        Console.WriteLine("The result is: {0}", (i+1));
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("please enter float number");
                        while (!Double.TryParse(Console.ReadLine(), out d))
                        {
                            Console.WriteLine("Please, focus and enter double");
                        }

                        Console.WriteLine("The result is: {0}", (d + 1.0));
                    }
                    break;
                default:
                    {
                        Console.WriteLine("please enter string");
                        s = Console.ReadLine();                        
                        Console.WriteLine("The result is: {0}", s + '*');
                    }
                    break;
            }

           
        }
    }
}
//