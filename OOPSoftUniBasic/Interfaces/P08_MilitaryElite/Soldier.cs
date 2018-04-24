using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite
{
    public abstract class Soldier:ISoldier
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; private set; }

        public Soldier(int id, string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
