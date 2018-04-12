using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Engine
    {
        public int engineSpeed;
        public int enginePower;
        public Engine(int engineSpeed, int enginePower)
        {
            this.enginePower = enginePower;
            this.engineSpeed = engineSpeed;
        }
    }
}
