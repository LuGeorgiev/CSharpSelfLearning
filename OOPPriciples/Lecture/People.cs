using System;


namespace Lecture
{
    public class People : IPeople
    {
        private string name;
        private string comment;

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            protected set
            {
                this.comment = value;
            }
        }

        public People(string name)
        {
            this.Name = name;
        }

        public People(string name, string commnet)
        {
            this.Name = name;
            this.Comment = comment;
        }

        public void Laught()
        {
            Console.WriteLine("Nice! {0} is laughting", this.name);
        }

        public override string ToString()
        {            
            return String.Format("My name is :{0}", this.Name);
        }
    }
}
