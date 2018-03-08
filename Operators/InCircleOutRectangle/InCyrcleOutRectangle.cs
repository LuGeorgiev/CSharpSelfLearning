using System;


namespace InCircleOutRectangle
{
    class InCyrcleOutRectangle
    {
        static void Main()
        {
            Console.WriteLine("Please enter X coordinate");
            float x = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Y coordinate");
            float y = float.Parse(Console.ReadLine());

            float distance = 0.0f;
            distance = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            
            Console.WriteLine((distance < 5 && (-1 > x||x > 5) && (-1 > y||y > 5)) ? "The point is in the cyrcle and out of rectangle" : "one of the conditions is not fulfilled");
        }
    }
}
