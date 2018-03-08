using System;
using System.Collections.Generic;


namespace MultitudeHash
{
    class StudentListExample
    {
        static void Main()
        {
            HashSet<string> aspNetStudents = new HashSet<string>();
            aspNetStudents.Add("S. Nakov");
            aspNetStudents.Add("V. Kolev");
            aspNetStudents.Add("M. Valkov");

            HashSet<string> silverlightStudents = new HashSet<string>();
            silverlightStudents.Add("S. Guthrie");
            silverlightStudents.Add("M. Valkov");

            HashSet<string> allStudents = new HashSet<string>();
            allStudents.UnionWith(aspNetStudents);
            allStudents.UnionWith(silverlightStudents);

            HashSet<string> intersectStudents = new HashSet<string>(aspNetStudents);
            intersectStudents.IntersectWith(silverlightStudents);

            Console.WriteLine("ASP.NET students: "+ GetListOfStudents(aspNetStudents));
            Console.WriteLine("Silverlight students: "+ GetListOfStudents(silverlightStudents));
            Console.WriteLine("All students: "+ GetListOfStudents(allStudents));
            Console.WriteLine("Students in both ASP.NET and Silverlight are: "+ GetListOfStudents(intersectStudents));

        }

        static string GetListOfStudents(IEnumerable<string> students)
        {
            string result = string.Empty;
            foreach (var student in students)
            {
                result += student + ", ";
            }
            if (result!=string.Empty)
            {
                result = result.TrimEnd(',', ' ');
            }
            return result;
        }
    }
}
