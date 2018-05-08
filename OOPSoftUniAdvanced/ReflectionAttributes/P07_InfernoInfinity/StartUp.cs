using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core.Factories;
using P07_InfernoInfinity.Models.Jems;
using P07_InfernoInfinity.Models.Weapons;
using System;

namespace P07_InfernoInfinity
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IJem newJem = new Ruby("Flawless");
            IWeaponFactory weaponFactory = new WeaponFactory();
            IJemFactory jemFactory = new JemFactory();
            
            IWeapon newAxe = weaponFactory.CreateWeapon("Axe", "Rare");
            IJem nextJem = jemFactory.CreateJem("Ruby", "Perfect");
            

            Console.WriteLine("Hello World!");
        }
    }
}
