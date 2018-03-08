using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    class Test
    {
        static void Main()
        {
            Student[] students = new Student[]
            {
                new Student("Ivan","Petrov",Grade.Apprentice),
                new Student("Penka","Tvurdata",Grade.Junior),
                new Student("Mikta","Lesnata",Grade.Collage_boy),
                new Student("Kraso","Burziq",Grade.Bachelor),
                new Student("Bobi","Skiorche",Grade.MBA),
                new Student("Martin","Petrov",Grade.Junior),
                new Student("Lazar","Petrovich",Grade.High_School_boy),
                new Student("Stefan","Georgiev",Grade.Master),
                new Student("Ivo","Krastev",Grade.Apprentice),
                new Student("Krasi","Kciq",Grade.Master),

            };

            IEnumerable<Student> query = students.OrderBy(student => student.LastName);

            foreach (Student student in query)
            {
                Console.WriteLine("{0} {1}",student.FirstName,student.LastName);
            }

            Console.WriteLine("Workers by wage:");

            IWorker[] workers = new IWorker[]
            {
                new Worker("Mitko", "Gotiniq",1000,8),
                new Worker("Galq", "Krasavicata",600,8.5m),
                new Worker("Ivancho", "Georgiev",2340,12),
                new Worker("Ivanka", "Marinova",2010,10.5m),
                new Worker("Marin", "Paraskevov",340,4),
                new Worker("Iliq", "Rijiq",2550,2),
                new Worker("Joro", "Georgiev",600,8),
                new Worker("Liq", "Ninjata",400,8),
                new Worker("Pavlin", "Turnovski",3128,8),
                new Worker("Reni", "Milata",1240,9),
                new Worker("Georgi", "Shalamanoff",880,7),
            };


            SortedDictionary<decimal, Worker> queryTwo = new SortedDictionary<decimal, Worker>();
            foreach (Worker item in workers)
            {
                queryTwo.Add(item.MoneyPerHour(), item);
            }

            foreach (KeyValuePair<decimal, Worker> kvp in queryTwo)
            {
                Console.WriteLine("{0:F2} money per hour is the wage of: {1}",kvp.Key,kvp.Value.LastName);
            }

            Console.WriteLine("All initialized humans");

            SortedDictionary<string, string> queryThree = new SortedDictionary<string, string>();
            foreach (Student item in students)
            {
                queryThree.Add(item.FirstName, item.LastName);
            }
            foreach (Worker item in workers)
            {
                queryThree.Add(item.FirstName, item.LastName);
            }

            foreach (var member in queryThree)
            {
                Console.WriteLine("{0} {1}",member.Key,member.Value);
            }
        }
    }
}
