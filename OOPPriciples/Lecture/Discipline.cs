using System;


namespace Lecture
{
    class Discipline:IDiscipline
    {
        private string disciplineName;
        private int lectures;
        private int excercises;

        public string DisciplineName
        {
            get
            {
                return this.disciplineName;
            }
            set
            {
                this.disciplineName = value;
            }
        }
        public int Lectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                this.lectures = value;
            }
        }
        public int Excercise
        {
            get
            {
                return this.excercises;
            }
            set
            {
                this.excercises = value;
            }
        }

        public Discipline(string name):this(name,1,1)
        {
            this.disciplineName = name;
        }
        public Discipline(string name, int lectures, int excercise)
        {
            this.DisciplineName = name;
            this.Lectures = lectures;
            this.Excercise = excercise;
        }

        public override string ToString()
        {
            return String.Format("{0} has: {1} hours lectures and {2} hours excercise", this.DisciplineName,this.Lectures, this.Excercise);     
        }
    }
}
