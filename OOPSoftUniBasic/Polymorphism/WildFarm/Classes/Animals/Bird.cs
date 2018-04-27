using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts.Animals;

namespace WildFarm.Classes.Animals
{
    public abstract class Bird : Animal, IBird
    {
        public abstract double WingSize { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
