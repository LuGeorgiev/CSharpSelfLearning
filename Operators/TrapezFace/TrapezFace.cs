using System;


namespace TrapezFace
{
    class TrapezFace
    {
        static void Main()
        {
            Console.WriteLine("Please, enter base, a");
            float a = float.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter base, b ");
            float b = float.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter height, h ");
            float h = float.Parse(Console.ReadLine());

            Console.WriteLine("The surface of the entered Trapezus is {0}", (float)(a+b)*h/2);

        }
    }
}
