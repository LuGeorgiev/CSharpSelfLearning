using System;
using System.Collections.Generic;
using System.Text;

namespace P01_CassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double heighht;

        public double Height
        {
            get { return heighht; }
            private set
            {
                if (!isZeroOrNegative(value, "Height"))
                {
                    heighht = value;
                }                
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (!isZeroOrNegative(value,"Width"))
                {
                    width = value;
                }
            }
        }
        public double Length
        {
            get { return length; }
            private set
            {
                if (!isZeroOrNegative(value, "Length"))
                {
                    length = value;
                }
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public void PrintBoxSurface()
        {
            double boxSurface = 2 * (this.Height * this.Length + this.Height * this.Width + this.Width * this.Length);

            Console.WriteLine($"Surface Area - {boxSurface:F2}");
        }
        public void PrintBoxLateralSurface()
        {
            double boxLateralSurface = this.Height * (2 * this.Length + 2* this.Width );

            Console.WriteLine($"Lateral Surface Area - {boxLateralSurface:F2}");
        }

        public void PrintBoxVolume()
        {
            double boxVolume = this.Height * this.Length  * this.Width;

            Console.WriteLine($"Volume - {boxVolume:F2}");
        }

        private bool isZeroOrNegative(double dimention, string dimentionName)
        {
            if (dimention<=0)
            {
                throw new ArgumentException($"{dimentionName} cannot be zero or negative.");
            }
            else
            {
                return false;
            }
        }
    }
}
