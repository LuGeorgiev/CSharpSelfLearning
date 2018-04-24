using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Interfaces
{
    public interface ILeutenantGeneral
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier soldier);
        void RemovePrivate(ISoldier soldier);
    }
}
