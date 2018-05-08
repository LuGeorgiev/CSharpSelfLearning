using P07_InfernoInfinity.Attributes;
using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models
{
    [Weapon("Pesho",3, "Used for C# OOP Advanced Course - Enumerations and Attributes.","Pesho","Svetlio")]   
    //[Weapon("Ivan",2, "Used for C# OOP Advanced Course - Enumerations and Attributes","Pesho","Svetlio")]   
    public class Weapon : IWeapon,IWeaponUpgrade
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
        
        public void AddJem(int socketIndex, IJem jem)
        {
            bool isValidIndex = CheckIfIndexIsValid(socketIndex);
            if (!isValidIndex)
            {
                return;
            }

            this.Sockets[socketIndex] = jem;
        }

        public void RemoveJem(int socketIndex)
        {
            bool isValidIndex = CheckIfIndexIsValid(socketIndex);
            if (!isValidIndex)
            {
                return;
            }
            this.Sockets[socketIndex] = null;
        }

        private bool CheckIfIndexIsValid(int socketIndex)
        {
            if (socketIndex < 0 || this.Sockets.Length - 1 < socketIndex)
            {
                return false;
            }
            return true;
        }

        public string Print()
        {
            int strength = 0;
            int agility = 0;
            int vitality = 0;
            foreach (var jem in this.Sockets)
            {
                if (jem!=null)
                {
                    strength += jem.Strength + (int)jem.JemClarity;
                    agility += jem.Agility + (int)jem.JemClarity;
                    vitality += jem.Vitality + (int)jem.JemClarity;
                }
            }

            int minDmg = this.MinDamage *(int)this.WeaponRarity+2*strength+agility;
            int maxDmg = this.MaxDamage* (int)this.WeaponRarity+3*strength+4*agility;

            return $"{minDmg}-{maxDmg} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }
    }
}
