using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Sword:Weapon
    {
        private const int MiminumDamage = 4;
        private const int MaximumDamage = 6;
        private const int NumberOfSockets = 3;

        public Sword(string rarity) 
            : base(MiminumDamage, MaximumDamage, rarity, NumberOfSockets)
        {

        }
    }
}
