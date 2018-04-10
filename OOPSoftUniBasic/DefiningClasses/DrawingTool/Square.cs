using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingTool
{
    class Square : Draw
    {
        public int Side { get; private set; }
        public Square( int side)
        {
            this.Side = side;
        }

        public override string DrawShape()
        {
            var builder = new StringBuilder();
            string elements = new string('-', this.Side);
            string emptyElements = new string(' ', this.Side);
            builder.AppendLine($"|{elements}|");
            for (int i = 0; i < this.Side-2; i++)
            {
                builder.AppendLine($"|{emptyElements}|");
            }
            builder.AppendLine($"|{elements}|");
            return builder.ToString();
        }
    }
}
