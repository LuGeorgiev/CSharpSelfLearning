using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeapnRepository
    {
        Dictionary<string, IWeapon> Weapons { get; }

        void AddWeapon(string name, IWeapon weapon);
        void PrintWeapon(string name);
    }
}
