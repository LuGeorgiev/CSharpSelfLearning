using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Jems
{
    public class Ruby : Jem
    {
        private const int DefaultStrength = 7;
        private const int DefaultAgility = 2;
        private const int DefaultVitality = 5;

        public Ruby(string jemClarity) 
            
            : base(DefaultStrength, DefaultAgility, DefaultVitality, jemClarity)
        {
        }
    }
}
