using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Jems
{
    public class Amethyst:Jem
    {
        private const int DefaultStrength = 2;
        private const int DefaultAgility = 8;
        private const int DefaultVitality = 4;

        public Amethyst(string jemClarity)

            : base(DefaultStrength, DefaultAgility, DefaultVitality, jemClarity)
        {
        }
    }
}
