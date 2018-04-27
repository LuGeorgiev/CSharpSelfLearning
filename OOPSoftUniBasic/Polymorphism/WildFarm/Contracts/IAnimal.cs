using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        IReadOnlyCollection<FoodType> EatableFoods { get; }
        void ProduceSound();
        void IncreaseWeight(IFood food);
    }
}
