using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public decimal WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            private set
            {
                if (value<1 || 12<value)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }

        public Worker(string first, string last, decimal salary, decimal hours) : base(first, last)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = hours;
        }

        public override string ToString()
        {
            var workerInfo = new StringBuilder();
            workerInfo.AppendLine(base.ToString());
            workerInfo.AppendLine($"Week Salary: {this.WeekSalary:F2}");
            workerInfo.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");

            var salaryPerHour = this.WeekSalary / (this.WorkHoursPerDay * 5m);

            workerInfo.AppendLine($"Salary per hour: {salaryPerHour:F2}");

            return workerInfo.ToString().TrimEnd();
        }
    }
}
