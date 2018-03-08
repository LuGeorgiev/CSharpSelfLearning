using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class RightAngleTriangle:Shape,ISurface
    {
        public RightAngleTriangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double Surface()
        {
            double surface;
            surface = this.Height * this.Width / 2.0;
            return surface;
        }
    }
}
