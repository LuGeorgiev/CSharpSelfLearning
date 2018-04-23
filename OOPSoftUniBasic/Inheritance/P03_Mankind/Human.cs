using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return firstName; }

            protected set
            {
                if (value.Length<=3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                if (Char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            protected set
            {
                if (value.Length<=2)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                if (Char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                lastName = value;
            }
        }

        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"First Name: {this.FirstName}");
            builder.AppendLine($"Last Name: {this.LastName}");

            return builder.ToString().TrimEnd();
        }
       
    }
}
