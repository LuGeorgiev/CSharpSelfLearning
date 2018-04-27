using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts.Animals
{
    interface ICat:IFeline
    {
        string Breed { get; }
    }
}
