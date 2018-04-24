using P08_MilitaryElite.Interfaces;
using System;


namespace P08_MilitaryElite.Soldiers
{
    public class Private : Soldier,IPrivate
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Salary have to eb positive!");
                }
                salary = value;
            }
        }

        public Private(string id, string firstName, string lastName,double salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString()+$" Salary: {this.Salary:F2}";
        }
    }
}
