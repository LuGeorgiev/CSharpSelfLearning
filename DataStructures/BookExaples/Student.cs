using System;


namespace BookExaples
{
    public class Student : IComparable<Student>
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int CompareTo(Student student)
        {
            int result = lastName.CompareTo(student.lastName);
            if (result==0)
            {
                result = firstName.CompareTo(student.firstName);
            }
            return result;
        }

        public override String ToString()
        {
            return firstName+" "+lastName;
        }
    }
}
