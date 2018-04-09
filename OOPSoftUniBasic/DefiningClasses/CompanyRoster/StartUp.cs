using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        static void Main()
        {
            var emploees = new List<Emploee>();
            var depertmentsSalary = new Dictionary<string, List<decimal>>();

            var numberOfEmploees = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEmploees; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var salary = decimal.Parse(input[1]);
                var position = input[2];
                var department = input[3];
                var email = "n/a";
                var age = -1;
                if (input.Length>4)
                {
                    var atIndex = input[4].IndexOf('@');
                    if (atIndex>0)
                    {
                        email = input[4];
                        if (input.Length ==6)
                        {
                            age = int.Parse(input[5]);
                        }
                    }
                    else
                    {
                        age = int.Parse(input[4]);
                    }
                }

                emploees.Add(new Emploee(name, salary, position, department, email, age));
                if (!depertmentsSalary.ContainsKey(department))
                {
                    depertmentsSalary[department] = new List<decimal>();
                }
                depertmentsSalary[department].Add(salary);
            }
            var highestAvgSalaryDep = depertmentsSalary.OrderByDescending(x => x.Value.Average()).FirstOrDefault();
            var sorderDepartment = emploees.Where(x => x.Department == highestAvgSalaryDep.Key)
                .OrderByDescending(x => x.Salary);
            Console.WriteLine($"Highest Average Salary: {highestAvgSalaryDep.Key}");
            foreach (var person in sorderDepartment)
            {
                Console.WriteLine($"{person.Name} {person.Salary:F2} {person.Email} {person.Age}");
            }

            
        }
    }
}
