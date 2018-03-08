

namespace StudentsAndWorkers
{
    public enum Grade {Master, Bachelor, MBA, Junior, Apprentice, Collage_boy, High_School_boy};

    class Student:Human,IHuman
    {        
        private Grade gradeOFStudent;
             
        
        public Student(string first, string last, Grade grade):base(first,last)
        {
            
            this.gradeOFStudent = grade;
        }
    }
}
