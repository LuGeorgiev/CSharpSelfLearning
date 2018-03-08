using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHWLINQ
{
    class Student:ISutudent
    {
        public string FirstName { get; private set;}
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public int FN { get; private set; }
        public string Tel { get; private set; }
        public string Email { get; private set; }
        public List<int> Marks { get; private set; }
        public int GroupNumber { get; private set; }





        public Student(string first, string last, int age, int fn,string tel, string mail, List<int> marks, int group)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
            this.FN = fn;
            this.Tel = tel;
            this.Email = mail;
            this.Marks = marks;
            this.GroupNumber = group;
        }
    }
}
