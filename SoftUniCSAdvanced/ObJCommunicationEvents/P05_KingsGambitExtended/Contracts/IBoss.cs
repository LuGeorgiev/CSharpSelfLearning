using System;
using System.Collections.Generic;
using System.Text;

namespace P05_KingsGambit.Contracts
{
    public interface IBoss
    {
        IReadOnlyCollection<ISubordinate> Subordinate { get; }

        void AddSubordinate(ISubordinate subordinate);

        void OnSubordinateDeath(object sender);
    }
}
