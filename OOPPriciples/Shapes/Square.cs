using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square:Shape,ISurface
    {
        public Square(double width)
        {
            this.Height = width;
            this.Width = width;
        }

        public override double Surface()
        {
            double surface;
            surface = this.Height * this.Width;
            return surface;
        }
    }
}
