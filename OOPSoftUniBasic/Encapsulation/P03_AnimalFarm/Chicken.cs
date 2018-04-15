using System;
using System.Collections.Generic;
using System.Text;

namespace P03_AnimalFarm
{
    public class Chicken
    {
        private int age;
        private string name;
        private double eggsPerDay;

        public double EggsPerDay
        {
            get { return eggsPerDay; }
            private set
            {
                eggsPerDay = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (value==null||value.Length==0||value.Contains(" "))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value<=0||15<=value)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                age = value;
            }
        }
        public Chicken(string name, int age)
        {
            Name = name;
            Age = age;
            EggsPerDay = CalculatProductivity(this.Age);
        }

        private double CalculatProductivity(int age)
        {
            if (0 < this.Age && this.Age <= 5)
            {
                return 1.5;
            }
            else if (5 < this.Age && this.Age <= 10)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return $"Chicken {this.Name} (age {this.Age}) can produce {this.EggsPerDay} eggs per day.";
        }
    }
}
