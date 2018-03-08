using System;


namespace InCircle
{
    class InCircle
    {
        static void Main()
        {
            Console.WriteLine("Please enter X coordinate");
            float x = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Y coordinate");
            float y = float.Parse(Console.ReadLine());

            float distance = 0.0f;

            distance = (float)Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2));
            Console.WriteLine(distance<5?"The point is in the cyrcle":"the point is out of the cyrcle");
        }
    }
}
