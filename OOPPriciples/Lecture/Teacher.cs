using System.Linq;
using System.Collections.Generic;


namespace Lecture
{
    class Teacher : People, IPeople, IClass
    {
        private List<Discipline> discipline;

        public Teacher(string name) : base(name)
        {
            this.discipline = new List<Discipline>();
        }
        public Teacher(string name, List<Discipline> disciplines) : base(name)
        {
            this.discipline = new List<Discipline>();
            if (disciplines.Count>0)
            {               
                this.discipline.AddRange(disciplines);                
            }
        }

        public List<Discipline> Discipline
        {
            get
            {
                return this.discipline.ToList();
            }
            set
            {
                this.discipline = value;
            }
        }

        public void AddDiciplineToTeacher(Discipline dicipline)
        {
            this.discipline.Add(dicipline);
        }

        public override string ToString()
        {
            return string.Format("My name is: {0} and I'm a teacher", this.Name);
        }
        
    }    
}
