using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts.Animals;

namespace WildFarm.Classes.Animals
{
    public abstract class Feline:Mammal,IFeline
    {
        protected ICollection<FoodType> eatableFood;
        
        public Feline(string name, string breed,double weight, string livingRegion)
        {
            this.Name = name;
            this.Breed = breed;
            this.Weight = weight;
            this.LivingReagion = livingRegion;
            this.FoodEaten = 0;
            this.eatableFood = new List<FoodType>();
        }

        public string Breed { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingReagion}, {this.FoodEaten}]";
        }
    }
}
