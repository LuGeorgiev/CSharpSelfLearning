using P07_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int MiminumDamage = 5;
        private const int MaximumDamage = 10;
        private const int NumberOfSockets = 4;

        public Axe( string rarity) 
            : base(MiminumDamage, MaximumDamage, rarity, NumberOfSockets)
        {
            
        }
    }
}
