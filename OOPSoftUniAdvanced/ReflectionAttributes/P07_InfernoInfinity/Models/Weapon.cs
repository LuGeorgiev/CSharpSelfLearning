using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models
{
    public abstract class Weapon : IWeapon
    {
        public Weapon(int minDmg, int maxDmg, string rarity, int sockets)
        {
            this.MinDamage = minDmg;
            this.MaxDamage = maxDmg;
            this.WeaponRarity = ParseRarity(rarity);
            this.Sockets = new IJem[sockets];
        }

        private Rarity ParseRarity(string rarity)
        {
            bool isValidRarity = Enum.TryParse(typeof(Rarity), rarity, true, out object weaponRarity);
            if (!isValidRarity)
            {
                throw new ArgumentException("Invalid Rarity!");
            }
            return (Rarity)weaponRarity;
        }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set;}

        public Rarity WeaponRarity { get; private set;}

        public IJem[] Sockets { get; private set; }
        
    }
}
