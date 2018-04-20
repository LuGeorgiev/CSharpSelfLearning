using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    class Student : Human
    {
        private string facultyNumber;

        public string FacultyNumber
        {
            get { return facultyNumber; }
            private set { facultyNumber = value; }
        }

        public Student(string first, string last, string facNumber) : base(first, last)
        {
            this.FacultyNumber = facNumber;
        }

        public override string ToString()
        {
            var studentInfo = new StringBuilder();
            studentInfo.AppendLine($"First Name: {this.FirstName}");
            studentInfo.AppendLine($"Last Name: {this.LastName}");
            studentInfo.AppendLine($"Week Salary: {this.FacultyNumber}");
            

            return studentInfo.ToString();
        }
    }
}
