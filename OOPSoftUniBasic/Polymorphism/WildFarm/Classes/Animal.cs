using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Classes
{
    public abstract class Animal : IAnimal
    {
        
        public abstract string Name { get; protected set; }
        public abstract double Weight { get; protected set; }
        public abstract int FoodEaten { get; protected set; }
        public abstract IReadOnlyCollection<FoodType> EatableFoods { get; }

        public abstract void ProduceSound();
        public abstract void IncreaseWeight(IFood food);
    }
}
