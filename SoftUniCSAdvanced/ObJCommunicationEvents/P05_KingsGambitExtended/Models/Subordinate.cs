using P05_KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05_KingsGambit.Models
{
    public abstract class Subordinate : ISubordinate
    {
        public event SubordinateDeathEventHandler DeathEvent;
        public Subordinate(string name,string action,int hitPoints)
        {
            this.Name = name;
            this.Action = action;
            this.isAlive = true;
            this.HitPoints = hitPoints;
        }
        public string Name { get; }

        public bool isAlive { get; private set; }

        public string Action { get; }

        public int HitPoints { get; private set; }


        public void Die()
        {
            this.isAlive = false;
            if (this.DeathEvent != null)
            {
                this.DeathEvent.Invoke(this);
            }
        }

        public virtual void ReactToAttack()
        {
            if (this.isAlive)
            {
                Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");

            }
        }

        public void TakeDmg()
        {
            this.HitPoints--;
            if (HitPoints<=0)
            {
                this.Die();
            }
        }
    }
}
