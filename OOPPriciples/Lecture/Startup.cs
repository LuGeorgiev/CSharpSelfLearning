using System;
using System.Collections.Generic;


namespace Lecture
{
    class Startup 
    {
        static void Main()
        {
            Student ivan = new Student("Ivan", "II a");
            IPeople petko = new People("Petko");

            Console.WriteLine(petko);
            petko.Laught();
            Console.WriteLine(ivan.ClassID);

            IDiscipline mathematics = new Discipline("Mathematics", 12, 18);
            Discipline literature = new Discipline("Literature", 10, 5);

            List<Discipline> disciplines = new List<Discipline>
            {
                new Discipline("Phisics",3,6),
                new Discipline("Oralogy",10,12)
            };

            Teacher milenova = new Teacher("Milenova",disciplines);
            foreach (Discipline item in disciplines)
            {
                Console.WriteLine(item);
            }

            milenova.AddDiciplineToTeacher(literature);
            Console.WriteLine(milenova);
                        
        }
    }
}
