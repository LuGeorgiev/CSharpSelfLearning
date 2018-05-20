using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Contracts
{
    public interface IBoss
    {
        IReadOnlyCollection<ISubordinate> Subordinate { get; }

        void AddSubordinate(ISubordinate subordinate);
    }
}
