﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    class Engine
    {
        private const string offset = "  ";

        public string model;
        public int power;
        public int displacement;
        public string efficiency;

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
            this.displacement = -1;
            this.efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement): this(model,power)
        {           
            this.displacement = displacement;
            this.efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency):this(model,power)
        {            
            this.displacement = -1;
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency):this(model,power,displacement)
        {            
            this.efficiency = efficiency;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.displacement == -1 ? "n/a" : this.displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.efficiency);

            return sb.ToString();
        }
    }
}
