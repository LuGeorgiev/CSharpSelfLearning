using System;
using System.Text;

namespace P06_Animals
{
    public class Animal : ISoundProducable
    {
        private const string ErrorMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                NotEmptyValidation(value);
                
                gender = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ErrorMessage);
                }
                age = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                NotEmptyValidation(value);
                name = value;
            }
        }

        private static void NotEmptyValidation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException(ErrorMessage);
            }
        }
        public virtual string ProduceSound()
        {
            return "Soundddddd!!";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} { this.Gender}")
                .AppendLine(this.ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
