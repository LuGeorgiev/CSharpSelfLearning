using System;
using System.Collections.Generic;
using System.Text;

namespace P05_KingsGambit.Contracts
{
    public interface IMortal
    {
        bool isAlive { get; }

        int HitPoints { get; }

        void TakeDmg();
        void Die();
    }
}
