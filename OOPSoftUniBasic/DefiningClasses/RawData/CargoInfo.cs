using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class CargoInfo
    {
        public int Weight { get; private set; }
        public string Type{ get; private set; }

        public CargoInfo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}
