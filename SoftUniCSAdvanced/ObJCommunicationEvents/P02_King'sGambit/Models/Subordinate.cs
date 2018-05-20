using P02_KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Models
{
    public abstract class Subordinate : ISubordinate
    {
        public Subordinate(string name,string action)
        {
            this.Name = name;
            this.Action = action;
            this.isAlive = true;
        }
        public string Name { get; }

        public bool isAlive { get; private set; }

        public string Action { get; }

        public void Die()
        {
            this.isAlive = false;
        }

        public virtual void ReactToAttack()
        {
            if (this.isAlive)
            {
                Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");

            }
        }
    }
}
