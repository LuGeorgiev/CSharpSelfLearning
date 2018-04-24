using P08_MilitaryElite.Soldiers.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces.IUtilities
{
    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepairItem(IRepair item);
    }
}
