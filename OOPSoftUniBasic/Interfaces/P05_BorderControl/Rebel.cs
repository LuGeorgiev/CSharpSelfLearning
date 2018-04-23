using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    public class Rebel : Human
    {
        public override int Food { get; set; }
        public string Group { get; private set; }

        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.Food = 0;
            this.Group = group;
        }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
