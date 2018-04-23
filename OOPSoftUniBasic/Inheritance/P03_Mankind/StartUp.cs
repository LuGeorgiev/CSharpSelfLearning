using System;

namespace P03_Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var studentInfo = Console.ReadLine().Split();
                var studenfFirstName = studentInfo[0];
                var studenfLastName = studentInfo[1];
                var studenfFacNumber = studentInfo[2];
                var student = new Student(studenfFirstName, studenfLastName, studenfFacNumber);

                var workerInfo = Console.ReadLine().Split();
                var workerFirstName = workerInfo[0];
                var workerLastName = workerInfo[1];
                var workerWeekSalary =decimal.Parse(workerInfo[2]);
                var workerHourPerDay =decimal.Parse(workerInfo[3]);
                var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerHourPerDay);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
