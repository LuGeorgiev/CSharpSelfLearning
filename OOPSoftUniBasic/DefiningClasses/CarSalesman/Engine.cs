using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        public string Model { get; private set; }
        public string Power { get; private set; }
        public string Displacement { get; private set; }
        public string Efficiency { get; private set; }

        public Engine(string model, string power, string displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
    }
}
