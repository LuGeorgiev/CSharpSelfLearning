using System;
using System.Collections.Generic;
using System.Text;


    public class Citizen : IPerson,IBirthable,IIdentifiable
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public Citizen(string name, int age, string id, string birtdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birtdate;
            this.Id = id;
        }
    }

