using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeaponUpgrade
    {
        void AddJem(int socketIndex, IJem jem);
        void RemoveJem(int socketIndex);
        string Print();
    }
}
