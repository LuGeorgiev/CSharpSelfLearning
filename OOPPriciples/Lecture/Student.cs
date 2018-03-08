using System;

namespace Lecture
{
    class Student: People, IPeople, IClass 
    {
        private string classID;

        public string ClassID
        {
            get
            {
                return this.classID;
            }
            set
            {
                this.classID = value;
            }
        }

        public Student(string name, string classID): base(name)
        {
            this.Name = name;
            this.classID = classID;
        }

        public Student(string name, string comment, string classID):base(name,comment)
        {
            this.Name = name;
            this.Comment = comment;
            this.classID = classID;
        }

        public override string ToString()
        {
            return String.Format("My name is {0} and I am from {1} class", this.Name, this.ClassID);
        }
    }
}
