using P07_InfernoInfinity.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        int MinDamage { get; }
        int MaxDamage { get; }
        Rarity WeaponRarity { get; }
        IJem[] Sockets { get; }
    }
}
