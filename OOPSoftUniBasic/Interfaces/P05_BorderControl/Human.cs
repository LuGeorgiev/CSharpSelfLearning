using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    public abstract class Human:IBuyer
    {
        public string Name { get;protected set; }
        public int Age { get; protected set; }

        public virtual int Food { get; set; }

        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual void BuyFood()
        {
            throw new NotImplementedException();
        }
    }
}
