using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    class Class:IClass
    {
        //Fields
        private string className;
        private List<Student> students;
        private List<Teacher> teachers;

        //Prop
        public string ClassName
        {
            get
            {
                return this.className;
            }
             set
            {
                this.className = value;
            }
        }
        public List<Student> Students
        {
            get
            {
                return this.students.ToList();
            }
            set
            {
                this.students = value;
            }
        }
        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers.ToList();
            }
            set
            {
                this.teachers = value;
            }
        }
        //Ctors
        public Class(string idOfTheClass)
        {
            this.ClassName = idOfTheClass;
        }
        public Class(string idOfClass, List<Student> students, List<Teacher> teachers)
        {
            this.ClassName = idOfClass;            
            this.Students.AddRange(students);
            this.Teachers.AddRange(teachers);

        }

        //Methods
        public override string ToString()
        {
            return String.Format("This is {0} class", this.className);
        }
        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }
        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }
    }

    internal interface IClass
    {
        string ClassName { get; set; }
        List<Student> Students {get; set;}
        List<Teacher> Teachers { get; set; }

        string ToString();
        void AddTeacher(Teacher teacher);
        void AddStudent(Student student);
    }
}
