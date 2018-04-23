using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    public class Pet : IBirthdate
    {
        public string Birthdate { get; private set; }
        public string  Name { get; private set; }

        public Pet(string name, string birthdate)
        {
            this.Birthdate = birthdate;
            this.Name = name;
        }
    }
}
