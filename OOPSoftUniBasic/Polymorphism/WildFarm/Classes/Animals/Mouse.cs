using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Contracts.Animals;

namespace WildFarm.Classes.Animals
{
    public class Mouse : Mammal, IMammal
    {
        private ICollection<FoodType> eatableFoods;

        public Mouse(string name, double weight, string livingReagion)
        {
            this.Name = name;
            this.Weight = weight;
            this.LivingReagion = livingReagion;
            this.eatableFoods = new List<FoodType>() { FoodType.Vegetable,FoodType.Fruit };
            this.FoodEaten = 0;
        }
        public override string LivingReagion { get; protected set ; }
        public override string Name { get ; protected set; }
        public override int FoodEaten { get ; protected set; }
        public override double Weight { get ; protected set; }

        public override IReadOnlyCollection<FoodType> EatableFoods
        {
            get
            {
                return (IReadOnlyCollection<FoodType>)this.eatableFoods;
            }
        }


        public override void IncreaseWeight(IFood food)
        {
            bool canEatFood = eatableFoods.Contains(food.TypeFood);

            if (canEatFood)
            {
                this.Weight += 0.10 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.TypeFood.ToString()}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
