using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Jems
{
    public class Emerald :Jem
    {
        private const int DefaultStrength = 1;
        private const int DefaultAgility = 4;
        private const int DefaultVitality = 9;

        public Emerald(string jemClarity)

            : base(DefaultStrength, DefaultAgility, DefaultVitality, jemClarity)
        {
        }
    }
}
