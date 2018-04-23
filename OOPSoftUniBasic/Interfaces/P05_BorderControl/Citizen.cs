using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    public class Citizen : Human,IId,IBirthdate
    {
        public string Id { get; private set; }      

        public string Birthdate { get; private set; }

        public override int Food { get;  set; }

        public Citizen(string name, int age):base(name,age)
        {
            this.Food = 0;
        }
        public Citizen(string name, int age, string id):this(name, age)
        {            
            this.Id = id;
        }
        public Citizen(string name, int age, string id, string birthdate):this(name,age,id)
        {
            this.Birthdate = birthdate;
            
        }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
