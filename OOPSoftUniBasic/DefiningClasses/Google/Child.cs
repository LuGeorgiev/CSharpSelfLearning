using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Child
    {
        public string Name { get; private set; }
        public string BirtDate { get; private set; }

        public Child(string name, string birthDate)
        {
            this.Name = name;
            this.BirtDate = birthDate;
        }
    }
}
