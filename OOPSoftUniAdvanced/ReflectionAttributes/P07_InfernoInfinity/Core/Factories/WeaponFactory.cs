using System;
using System.Reflection;
using System.Linq;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core.Factories
{
    public class WeaponFactory:IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string rarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(x => x.Name == weaponType);

            if (model==null)
            {
                throw new ArgumentException("Invalid weapon type");
            }
            if (!typeof(IWeapon).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{weaponType} in not a weapon");
            }

            IWeapon weapon = (IWeapon)Activator.CreateInstance(model, new object[] { rarity });

            return weapon;
        }
    }
}
