using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingTool
{
    class Rectangle : Draw
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override string DrawShape()
        {
            var builder = new StringBuilder();
            string elements = new string('-', this.Width);
            string emptyElements = new string(' ', this.Width);
            builder.AppendLine($"|{elements}|");
            for (int i = 0; i < this.Height - 2; i++)
            {
                builder.AppendLine($"|{emptyElements}|");
            }
            builder.AppendLine($"|{elements}|");
            return builder.ToString();
        }
    }
}
