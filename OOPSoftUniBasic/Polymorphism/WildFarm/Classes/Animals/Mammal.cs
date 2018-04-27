using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Contracts.Animals;

namespace WildFarm.Classes.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        
        public abstract string LivingReagion { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingReagion}, {this.FoodEaten}]";
        }

        
    }
}
