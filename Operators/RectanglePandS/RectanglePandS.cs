using System;


namespace RectanglePandS
{
    class RectanglePandS
    {
        static void Main()
        {
            Console.WriteLine("Please, enter rectangle side a length");
            float a = float.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter rectangle side b length ");
            float b = float.Parse(Console.ReadLine());

            Console.WriteLine("Perimeter of the rectangle is:{0} \nSurface of th erectangle is:{1}", (float)(a+b)*2, (float)a*b);
        }
    }
}
