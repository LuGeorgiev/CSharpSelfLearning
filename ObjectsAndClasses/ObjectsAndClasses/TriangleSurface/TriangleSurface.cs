using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSurface
{
    class TriangleSurface
    {
        private double sideA;
        private double sideB;
        private double sideC;
        private double height;
        private int angle;

        public Double SideA { get { return this.sideA; } set { this.sideA = value; } }
        public Double SideB { get { return this.sideB; } set { this.sideB = value; } }
        public Double SideC { get { return this.sideC; } set { this.sideC = value; } }
        public Double Height { get { return this.height; } set { this.height = value; } }

        public TriangleSurface(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public TriangleSurface(double sideA, double height)
        {
            this.sideA = sideA;
            this.height = height;            
        }

        public TriangleSurface(double sideA, double sideB, int angle)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.angle = angle;
        }

        public static double Surface(double a, double b, double c)
        {
            double surface=0.0;
            double p = (a + b + c) / 2.0;
            surface = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            return surface;
        }

        public static double Surface(double a, double heightA)
        {
            double surface = 0.0;
            surface = a * heightA / 2.0;
            return surface;
        }

        public static double Surface(double a, double b, int angleAB)
        {
            double surface = 0.0;
            surface = (a * b * Math.Sin(angleAB * Math.PI / 180.0))/2.0;
            return surface;
        }

        static void Main()
        {
            TriangleSurface first  = new TriangleSurface(5.0, 6.0);
            TriangleSurface second = new TriangleSurface(5.0, 6.0, 7.0);
            TriangleSurface third  = new TriangleSurface(5.0, 6.0, 35);
            TriangleSurface forth  = new TriangleSurface(5.0, 6.0, 45);
                        
            Console.WriteLine(Surface(first.sideA, first.height));
            Console.WriteLine(Surface(second.sideA, second.sideB, second.SideC));
            Console.WriteLine(Surface(third.sideA, third.sideB,third.angle));
            Console.WriteLine(Surface(forth.sideA, forth.sideB, forth.angle));

        }
    }
}
