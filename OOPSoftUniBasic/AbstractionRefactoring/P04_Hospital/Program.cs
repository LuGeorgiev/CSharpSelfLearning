using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {

            var listOfDoctors = new List<Doctor>();
            var listOfDepartments = new List<Department>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var SecondName = tokens[2];
                var patientName = tokens[3];
                var doctorName = firstName + SecondName;

                if (!listOfDoctors.Any(x=>x.Name== doctorName))
                {
                    listOfDoctors.Add(new Doctor(doctorName));
                }
                if (!listOfDepartments.Any(x => x.departmentName == departament))
                {
                    listOfDepartments.Add(new Department(departament));
                }

                var doctorFound = listOfDoctors.FirstOrDefault(x => x.Name == doctorName);
                doctorFound.AddPatient(patientName);
                var departmentFound = listOfDepartments.FirstOrDefault(x => x.departmentName == departament);
                departmentFound.AddPatient(patientName);              
                
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    var findDepartment = listOfDepartments
                        .FirstOrDefault(x => x.departmentName == args[0]);
                    if (findDepartment!=null)
                    {
                        findDepartment.PrintPatients();
                    }
                }
                else if (args.Length == 2 && 48<=args[1][0]&& args[1][0]<=57)
                {
                    int roomNumber = int.Parse(args[1])-1;
                    string department = args[0];

                    var findDepartment = listOfDepartments
                        .FirstOrDefault(x => x.departmentName == args[0]);
                    if (findDepartment != null)
                    {
                        findDepartment.PrintPatientInRoom(roomNumber);
                    }
                }
                else
                {
                    string doctorFullName = args[0] + args[1];
                    var findDoctor = listOfDoctors.FirstOrDefault(x => x.Name == doctorFullName);
                    if (findDoctor!=null)
                    {
                        findDoctor.PrintPatiets();
                    }                    
                }
                command = Console.ReadLine();
            }
        }
    }
}
