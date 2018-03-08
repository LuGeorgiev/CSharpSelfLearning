using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle:Shape,ISurface
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public override double  Surface()
        {
            double surface;

            surface = this.Height * this.Width;
            return surface;
        }
    }
}
