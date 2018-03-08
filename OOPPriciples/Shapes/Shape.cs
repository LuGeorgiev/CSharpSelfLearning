using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        private double height;
        private double width;

        public double Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value<=0)
                {
                    throw new ArgumentNullException("Height have to be more than 0");
                }
                this.height = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Width have to be more than 0");
                }
                this.width = value;
            }
        }
        public abstract double Surface();
    }
}
