using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    class Human
    {
        private string firstName;
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            protected set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            protected set
            {
                if (value.Length<=3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                if (!Char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                firstName = value;
            }
        }

        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
