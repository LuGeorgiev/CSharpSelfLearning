using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    class Knife:Weapon
    {
        private const int MiminumDamage = 3;
        private const int MaximumDamage = 4;
        private const int NumberOfSockets = 2;

        public Knife(string rarity)
            : base(MiminumDamage, MaximumDamage, rarity, NumberOfSockets)
        {

        }
    }
}
