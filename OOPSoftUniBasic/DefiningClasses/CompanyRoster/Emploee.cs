using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    class Emploee
    {
        private string name;
        private int age;
        private decimal salary;
        private string position;
        private string department;
        private string email;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public decimal Salary
        {
            get { return salary; }
            private set { salary = value; }
        }
        public string Position
        {
            get { return position; }
            private set { position = value; }
        }
        public string Department
        {
            get { return department; }
            private set { department = value; }
        }
        public string Email
        {
            get { return email; }
            private set { email = value; }
        }
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }
      
        public Emploee(string name, decimal salary, string position, string department,string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }


    }
}
