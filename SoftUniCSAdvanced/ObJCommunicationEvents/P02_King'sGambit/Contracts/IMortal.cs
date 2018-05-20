using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Contracts
{
    public interface IMortal
    {
        bool isAlive { get; }
        void Die();
    }
}
