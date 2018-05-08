using P07_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_InfernoInfinity.Repository
{
    public class WeaponRepository:IWeapnRepository
    {
        private Dictionary<string,IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }

        public Dictionary<string, IWeapon> Weapons
        {
            get { return this.weapons; }
            private set { this.weapons = value; }
        }

        public void AddWeapon(string name, IWeapon weapon)
        {
            if (this.weapons.ContainsKey(name))
            {
                throw new ArgumentException($"{name} already exists!");
            }
            weapons[name] = weapon;
        }

        public void PrintWeapon(string name)
        {
            if (!this.weapons.ContainsKey(name))
            {
                throw new ArgumentException($"{name} do not exist in repository!");
            }

            IWeaponUpgrade weapon = (IWeaponUpgrade)this.weapons[name];

            Console.WriteLine($"{name}: {weapon.Print()}");
        }
    }
}
