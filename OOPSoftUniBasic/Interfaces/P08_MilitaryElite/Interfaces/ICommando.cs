using P08_MilitaryElite.Interfaces.IUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions
        {
            get;
        }

        void AddMission(IMission mission);
    }
}
