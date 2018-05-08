using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core.Factories;
using P07_InfernoInfinity.Models.Jems;
using P07_InfernoInfinity.Models.Weapons;
using P07_InfernoInfinity.Repository;
using System.Linq;
using System;
using P07_InfernoInfinity.Core;

namespace P07_InfernoInfinity
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWeapnRepository repository = new WeaponRepository();
            AttributeTracker attributes = new AttributeTracker();
            

            string input = "";
            while ((input=Console.ReadLine())!="END")
            {
                var commands = input.Split(';');
                var command = commands[0];
                if (command == "Add")
                {
                    var weaponName = commands[1];
                    var index = int.Parse(commands[2]);
                    var jemData = commands[3].Split();
                    var jemClarity = jemData[0];
                    var jemType = jemData[1];

                    AddJemToWeapon(repository, weaponName, index, jemType, jemClarity);
                }
                else if (command == "Create")
                {
                    var weaponData = commands[1].Split();
                    var weaponRarity = weaponData[0];
                    var weaponType = weaponData[1];
                    var weaponName = commands[2];

                    AddWeaponToRepository(repository, weaponName, weaponType, weaponRarity);
                }
                else if (command == "Remove")
                {
                    var weaponName = commands[1];
                    var index = int.Parse(commands[2]);

                    RemoveJemFromWeapon(repository, weaponName, index);
                }
                else if (command == "Print")
                {
                    var weaponName = commands[1];
                    PrintWeaponStatistics(repository, weaponName);
                }
                else if (command == "Author")
                {
                    attributes.Author();
                }
                else if (command == "Revision")
                {
                    attributes.Revision();
                }
                else if (command == "Description")
                {
                    attributes.Description();
                }
                else if (command == "Reviewers")
                {
                    attributes.Reviewers();
                }
            }
            
        }

        private static void PrintWeaponStatistics(IWeapnRepository repository, string weaponName)
        {
            IWeaponUpgrade weaponToPrint = FindWeaponInRepository(repository, weaponName);
            repository.PrintWeapon(weaponName);           
        }

        private static void RemoveJemFromWeapon(IWeapnRepository repository, string weaponName, int index)
        {
            IWeaponUpgrade weaponToDowngrade = FindWeaponInRepository(repository, weaponName);

            
            weaponToDowngrade.RemoveJem(index);
        }

        private static void AddWeaponToRepository
            (IWeapnRepository repository, string weaponName, string weaponType, string weaponRarity)
        {
            IWeaponFactory weaponFactory = new WeaponFactory();

            repository.AddWeapon(weaponName, weaponFactory.CreateWeapon(weaponType, weaponRarity));
        }

        private static void AddJemToWeapon
            (IWeapnRepository repository, string weaponName, int index, string jemType, string jemClarity)
        {
            IWeaponUpgrade weaponToUpgrade = FindWeaponInRepository(repository, weaponName);
            IJemFactory jemFactory = new JemFactory();

            weaponToUpgrade.AddJem(index, jemFactory.CreateJem(jemType, jemClarity));
        }

        private static IWeaponUpgrade FindWeaponInRepository(IWeapnRepository repository, string weaponName)
        {
            IWeapon weapon = repository
                .Weapons
                .FirstOrDefault(x => x.Key == weaponName)
                .Value;

            return (IWeaponUpgrade)weapon;
        }
    }
}
