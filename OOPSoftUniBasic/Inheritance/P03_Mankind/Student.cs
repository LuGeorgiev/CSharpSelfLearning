using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public string FacultyNumber
        {
            get { return facultyNumber; }
            private set
            {
                if (!IsFacultyValid(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                facultyNumber = value;
            }
        }


        public Student(string first, string last, string facNumber) : base(first, last)
        {
            this.FacultyNumber = facNumber;
        }

        public override string ToString()
        {
            var studentInfo = new StringBuilder();
            studentInfo.AppendLine(base.ToString());
            studentInfo.AppendLine($"Faculty number: {this.FacultyNumber}");
            

            return studentInfo.ToString().TrimEnd();
        }

        private bool IsFacultyValid(string facultyNumber)
        {
            if (facultyNumber.Length < 5 || facultyNumber.Length > 10)
            {
                return false;
            }
            else
            {
                foreach (var letter in facultyNumber)
                {
                    bool isDigit = 48 <= letter && letter <= 57;
                    bool isUpper = 65 <= letter && letter <= 90;
                    bool isLower = 97 <= letter && letter <= 122;

                    if (!(isDigit||isLower||isUpper))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
