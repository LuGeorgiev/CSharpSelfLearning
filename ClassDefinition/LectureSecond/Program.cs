using System;


namespace LectureSecond
{
    struct Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    struct Vector
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;            
        }

        public static Point2D operator +(Point2D point, Vector vector)
        {
            return new Point2D(point.X+vector.X, point.Y+vector.Y);
        }
    }
    
    class Startup
    {
        static void Main()
        {
            Point2D startPoint = new Point2D(0, 0);
            Vector jumpVector = new Vector(6, 1);
            Point2D positionAfterJump = startPoint + jumpVector;
            Console.WriteLine(positionAfterJump.X+" "+positionAfterJump.Y);
        }
    } 
}
