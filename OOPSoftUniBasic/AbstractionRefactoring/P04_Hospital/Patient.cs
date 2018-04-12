using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Patient
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Patient(string name)
        {
            this.Name = name;
        }
    }
}
