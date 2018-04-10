using System;

namespace DrawingTool
{
    public class StartDrawing
    {
        static void Main(string[] args)
        {
            var shape = Console.ReadLine();
            if (shape=="Square")
            {
                var side = int.Parse(Console.ReadLine());
                var square = new Square(side);
                Console.WriteLine(square.DrawShape());                
            }
            else
            {
                var width = int.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                var rectangle = new Rectangle(height,width);
                Console.WriteLine(rectangle.DrawShape());                
            }
        }
    }
}
