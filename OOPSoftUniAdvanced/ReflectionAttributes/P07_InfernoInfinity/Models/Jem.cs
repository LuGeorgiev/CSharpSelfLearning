using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models
{
    public abstract class Jem : IJem
    {
        public Jem(int strength, int agility, int vitality, string jemClarity)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.JemClarity = ParseClarity(jemClarity);
        }

        private Clarity ParseClarity(string jemClarity)
        {
            bool isClarityValid = Enum.TryParse(typeof(Clarity), jemClarity, true, out object clarity);
            if (!isClarityValid)
            {
                throw new ArgumentException("Invalid Jem Clarity");
            }

            return (Clarity)clarity;
        }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public Clarity JemClarity { get; private set; }
    }
}
