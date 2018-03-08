using System;
using System.Collections.Generic;
using System.Linq;


namespace StudentHWLINQ
{
    class Begin
    {
        static void Main()
        {
            List<ISutudent> students = new List<ISutudent>
            {
                new Student("Pavlin", "Tishev",39, 231006,"+359 883 359 265","Ptin@gmail.bg", new List<int>{5,4,3,5,5,2,3}, 3),
                new Student("Ivan", "Patrishkov",31,356110,"+359 828 616 326", "iv.ku@abv.bg", new List<int>{6,6,6,6,6,6,6},2),
                new Student("Siqna", "Georgieva",10,236905,"02 975 698", "siqnkaBubalanka@abv.com",new List<int>{4,5,6,2,5,3,2,6},4),
                new Student("Martin", "Georgiev",7,235606,"+3592  23 23 26","kuh@gmail.co", new List<int>{ 2,3,2,3,2,4},2),
                new Student("Georgi", "Lyubomirov",23,956805,"+458 569 965695","J@Orko@abv.bg",new List<int>{6 ,6,2,5,5,4,5},3),
                new Student("Desislava", "Colova",27,355916,"02 568 954","artexa@gmail.com",new List<int>{ 4,6,2,3,5,5,2,6,6},7)
            };

            List<Group> departments = new List<Group>
            {
                new Group(2,"Metematicians"),
                new Group (3,"NAS gys"),
                new Group(4,"Physicians")
            };

            string[] strings = new string[] { "one", "three", "fif", "longest" };
            #region
            // Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
            //Use LINQ query operators.
            //var firstBeforeLast = students
            //    .Where(x => string.Compare(x.FirstName, x.LastName) == -1)
            //    .OrderBy(o => o.FirstName)
            //    .Select(x=>x.FirstName+" " +x.LastName);
            //foreach (var item in firstBeforeLast)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24
            //var between18and24 = students
            //    .Where(x => x.Age >= 18 && x.Age < 24)
            //    .OrderByDescending(x => x.LastName)
            //    .Select(g => new { g.FirstName, g.LastName });

            //foreach (var youth in between18and24)
            //{
            //    Console.WriteLine(youth.FirstName+" "+youth.LastName);
            //}
            //Console.WriteLine();

            //Using LINQ OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.

            //var alphabeticOrder = students
            //    .OrderByDescending(x => x.FirstName)
            //    .ThenByDescending(x => x.LastName)
            //    .Select(x=>x);
            //foreach (var stud in alphabeticOrder)
            //{
            //    Console.WriteLine(stud.FirstName +" "+stud.LastName);
            //}
            //Console.WriteLine();

            //Create a List<Student> with sample students. Select only the students that are from group number 2.
            //Use LINQ query.Order the students by FirstName.
            //var seconGroup = students
            //    .Where(x => x.GroupNumber == 2)
            //    .OrderBy(x => x.FirstName)
            //    .Select(x => x.FirstName + " " + x.LastName + " fromGroup #" + x.GroupNumber);
            //foreach (var student in seconGroup)
            //{
            //    Console.WriteLine(student);
            //}

            //Extract all students that have email in abv.bg.

            //var mailAbv = students
            //    .Where(x => x.Email.EndsWith("abv.bg"))
            //    .Select(x => x.FirstName+" "+x.LastName+" has mail in abv.bg");
            //foreach (var n in mailAbv)
            //{
            //    Console.WriteLine(n);
            //}

            //Extract all students with phones in Sofia.

            //var sofiaPhones = students
            //    .Where(x => x.Tel.StartsWith("02") || x.Tel.StartsWith("+3592"))
            //    .Select(x => x.FirstName + " " + x.LastName + " has phone from Sofia");
            //foreach (var sof in sofiaPhones)
            //{
            //    Console.WriteLine(sof);
            //}

            //Select all students that have at least one mark 
            //Excellent(6) into a new anonymous class that has properties – FullName and Marks.

            //var oneExAtLeast = from student in students
            //                   where student.Marks.Contains(6)
            //                   select student.FirstName+" "+student.LastName;
            //foreach (var item in oneExAtLeast)
            //{
            //    Console.WriteLine(item);
            //}

            //Write down a similar program that extracts the students with exactly two marks "2".
            //Use extension methods.
            //foreach (var student in students)
            //{
            //    if (student.ExactMarksNumber(2,2))
            //    {
            //        Console.WriteLine(student.FirstName);
            //    }
            //}
            //                //Second way
            //var weakStud = from student in students
            //               where student.ExactMarksNumber(2, 2)
            //               orderby student.FirstName
            //               select student.FirstName + " " + student.LastName;
            //foreach (var person in weakStud)
            //{
            //    Console.WriteLine(person);
            //}

            //Extract all Marks of the students that enrolled in 2006.
            //(The students from 2006 have 06 as their 5 - th and 6 - th digit in the FN).
            //var marksOfStdents = students
            //    .Where(x => x.FN % 100 == 6)
            //    .Select(x=>x.Marks);
            //foreach (var item in marksOfStdents)
            //{
            //    Console.WriteLine(String.Join(", ",item));
            //}

            // Second way for previous task
            //var marksOfStdents =  students
            //                     .Where ( x=> x.FN%100==6)                                 
            //                     .Select(x=> new
            //                     {
            //                         x.FN,
            //                         x.Marks
            //                     });                

            //foreach (var item in marksOfStdents)
            //{
            //    Console.WriteLine(item.FN);
            //    Console.WriteLine(string.Join(", ", item.Marks));               
            //}
            #endregion
            //Create a class Group with properties GroupNumber and DepartmentName.
            //Introduce a property GroupNumber in the Student class.
            //Extract all students from "Mathematics" department.
            //Use the Join operator.
            //var query = from student in students
            //            join department in departments on student.GroupNumber equals department.GroupNumber
            //            where department.GroupNumber.Equals(2)
            //            orderby student.FirstName
            //            select new { department.DepartmentName, student };

            //foreach (var department in query)
            //{
            //    Console.WriteLine(department.DepartmentName + " " + department.student.FirstName);

            //}

            ////Write a program to return the string with maximum length from an array of strings.
            ////Use LINQ
            //var longest = strings
            //    .OrderByDescending(l => l.Length)
            //    .First();
            //Console.WriteLine(longest);

            //Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
            //Use LINQ #18
            var studentsByGroup = from student in students
                                  orderby student.GroupNumber
                                  group student by student.GroupNumber into kurs                                  
                                  select new {Nomer=kurs.Key, Member=kurs };
            foreach (var member in studentsByGroup)
            {
                Console.WriteLine(member.Nomer);
                foreach (var item in member.Member)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                    Console.WriteLine(string.Join(", ", item.Marks));
                    Console.WriteLine();
                }
            }

            //Expension Methods scenarion #19
            var studGroupExtension = students
                .OrderBy(x => x.GroupNumber)
                .GroupBy(y => y.GroupNumber)
                .Select(z => 
                    new {
                    Nomer = z.Key,
                    Member = z });

            foreach (var member in studGroupExtension)
            {
                Console.WriteLine(member.Nomer);
                foreach (var item in member.Member)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                    Console.WriteLine(string.Join(", ", item.Marks));
                    Console.WriteLine();
                }
            }

        }
    }
}
