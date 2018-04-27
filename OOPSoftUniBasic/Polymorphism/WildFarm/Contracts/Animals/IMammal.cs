using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts.Animals
{
    public interface IMammal:IAnimal
    {
        string LivingReagion { get; }
    }
}
