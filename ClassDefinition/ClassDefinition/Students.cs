using System;


namespace ClassDefinition
{
    public enum University
        {
            UNSS, TU, UASG, VIAS, SU
        }
    public enum Specialty
        {
            TelecomEngineer, Medician, SWEngineer, Economist
        }

    class Students
    {
        private string firstName;
        private string secondName;
        private string lastName;
        private uint studentID;
        private string eMail;
        private string cellPhone;
        private University university;
        private Specialty specialty;

        static int numberOfStudents=0;


        public string FirstName
        {
            get { return this.firstName; }
            set {this.firstName=value ;}
        }
        public string SecondName
        {
            get { return this.secondName; }
            set { this.secondName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public uint StudendID
        {
            get { return this.studentID; }
            set
            {
                if (value<1||value>10000)
                {
                    throw new ArgumentException("Studend ID should be between 1 and 9999");
                }
                    this.studentID = value;
            }
        }
        public string EMail
        {
            get { return this.eMail; }
            set
            {
                int length = value.Length;
                int index = value.IndexOf('@');
                int dotIndex = value.LastIndexOf('.');
                if (length<6||index==-1||dotIndex==-1||index>dotIndex)
                {
                    throw new ArgumentException("Invalid e-mail address");
                }
                this.eMail = value;
            }
        }
        public string CellPhone
        {
            get { return this.cellPhone; }
            set
            {
                int length = value.Length;                
                if (length < 8)
                {
                    throw new ArgumentException("Invalid phone number");
                }
                this.cellPhone = value;
            }
        }

        public Students(string first, string second, string last, string mail, string phone)
        {
            this.FirstName = first;
            this.SecondName = second;
            this.LastName = last;
            this.EMail = mail;
            this.CellPhone = phone;
            Students.numberOfStudents++;
        }
        internal Students(string first, string second, string last, string mail, string phone, University uni , Specialty spec, uint id)
        {
            FirstName = first;
            SecondName = second;
            LastName = last;
            EMail = mail;
            CellPhone = phone;
            StudendID = id;
            university = uni;
            specialty = spec;
            numberOfStudents++;
        }
        public Students(uint id, University uni, Specialty spec)
        {
            StudendID = id;
            numberOfStudents++;
        }
        static Students()
        {
            var test = new Students("Kalin","Ivanov", "Ivanov", "luck@abv.bg","0898 567 345");
            var test1 = new Students("Kalinka","Ivanov", "Ivan", "luck@345.bg","0898 234 345",University.VIAS,Specialty.Economist, 9695);
            var test2 = new Students(1234, University.TU,Specialty.SWEngineer);            
        }
        
        public void PrintStudentFullInfo()
        {
            Console.WriteLine(FirstName);
            Console.WriteLine(SecondName);
            Console.WriteLine(LastName);
            Console.WriteLine(StudendID);
            Console.WriteLine(EMail);
            Console.WriteLine(CellPhone);
            Console.WriteLine(university);
            Console.WriteLine(specialty);
            Console.WriteLine(StudendID);
            Console.WriteLine("there are {0} students in DB ",Students.numberOfStudents);
        }

        public static void PrintStatic(Students student)
        {
            Console.WriteLine(student.firstName);
            Console.WriteLine(student.secondName);
            Console.WriteLine(student.LastName);
            Console.WriteLine(student.university);
            Console.WriteLine(student.StudendID);
        }

        static void Main()
        {
            var firstStudent = new Students("Ivan", "Ivanov", "Ivanov", "ivan@gmail.com", "0898 400 698");
            var secondStudent = new Students("Ivan", "Petrov", "Dimitrov", "ivan_petrov@gmail.com", "0898 900 698");
            var thirdStudent = new Students("Ivanka", "Petrova", "Dimitrova", "ivka@abv.bg", "0898 69 69 69");
            var forthStudent = new Students("Petrana", "Simova", "Sazdova", "Pepi@gmail.com", "0898 69 69 69", University.TU , Specialty.Medician , 5566);

            forthStudent.PrintStudentFullInfo();
           // PrintStatic(test);  // I cannot print Students cr3eated with static constructor
            
        }
    }
}
