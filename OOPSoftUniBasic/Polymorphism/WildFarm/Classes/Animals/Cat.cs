﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Contracts.Animals;

namespace WildFarm.Classes.Animals
{
    public class Cat : Feline, IFeline
    {
        public Cat(string livingReagion, string name, double weight,string breed):base(name,breed,weight,livingReagion)
        {           
            
            this.eatableFood.Add(FoodType.Meat);
            this.eatableFood.Add(FoodType.Vegetable);
        }

        public override string LivingReagion { get ; protected set ; }
        public override string Name { get ;  protected set ; }
        public override double Weight { get; protected set ; }
        public override int FoodEaten { get; protected set ; }

        public override IReadOnlyCollection<FoodType> EatableFoods
        {
            get
            {
                return (IReadOnlyCollection<FoodType>)this.eatableFood;
            }
        }

        public override void IncreaseWeight(IFood food)
        {
            bool canEatFood = eatableFood.Contains(food.TypeFood);

            if (canEatFood)
            {
                this.Weight += 0.30 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.TypeFood.ToString()}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
