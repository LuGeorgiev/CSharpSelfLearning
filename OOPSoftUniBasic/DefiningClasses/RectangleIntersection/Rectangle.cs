using System;
using System.Collections.Generic;
using System.Text;


     public class Rectangle
    {
        public string Id { get; private set; }
        public double ASide { get; private set; }
        public double BSide { get; private set; }
        public double CSide { get; private set; }
        public double DSide { get; private set; }

        public Rectangle(string id,double width, double height, double xAxcis, double yAxis)
        {
            this.Id = id;
            this.ASide = yAxis - height;
            this.CSide = yAxis;
            this.BSide = xAxcis +width;
            this.DSide = xAxcis ;
        }

        public static bool AreRectanglesIntersected(Rectangle first, Rectangle second)
        {

            //second a is between a and c first
            if ((first.ASide <= second.ASide && second.ASide <= first.CSide) &&
                ((first.DSide <= second.BSide && first.BSide >= second.BSide) || (first.DSide <= second.DSide && first.BSide >= second.DSide)))
            {
                return true;
            }
            else if ((first.ASide <= second.CSide && second.CSide < first.CSide) &&
                ((first.DSide <= second.BSide && first.BSide >= second.BSide) || (first.DSide <= second.DSide && first.BSide >= second.DSide)))
            {
                return true;
            }

            return false;
        }
    }

