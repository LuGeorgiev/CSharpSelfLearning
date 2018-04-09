using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class EngineInfo
    {
        public int Speed { get; private set; }
        public int Power { get; private set; }

        public EngineInfo(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }
}
