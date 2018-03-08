using System;

namespace StudentsAndWorkers
{
    public abstract class Human:IHuman
    {
        //Fields
        private string firstName;
        private string lastName;

        //Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name should not be empty");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name should not be empty");
                }
                
                this.lastName = value;
                
            }
        }

        //Ctor
        public Human(string first, string last)
        {
            this.LastName = last;
            this.FirstName = first;
        }
    }
}
