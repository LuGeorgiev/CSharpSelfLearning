using System;

namespace P01_CassBox
{
    public class StartBox
    {
        static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            try
            {
                var box = new Box(length, width, height);

                box.PrintBoxSurface();
                box.PrintBoxLateralSurface();
                box.PrintBoxVolume();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
