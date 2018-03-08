using System;


namespace CyrcleSurfaceAndPerimmeter
{
    class SyrvleSurfaceAndPerrimeter
    {
        static void Main()
        {
            Console.WriteLine("Plese, enter teh radius of the cyrcle");
            float r = float.Parse(Console.ReadLine());
            double surface = Math.PI * r * r;
            double perimeter = Math.PI * 2 * r;

            Console.WriteLine("Area = {0}", surface);
            Console.WriteLine("Perimeter = {0}", perimeter);
        }
    }
}
