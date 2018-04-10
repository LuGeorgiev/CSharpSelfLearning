using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Parent
    {
        public string Name { get; private set; }
        public string BirthDate { get; private set; }

        public Parent(string name, string birthDate)
        {
            this.BirthDate = birthDate;
            this.Name = name;
        }

    }
}
