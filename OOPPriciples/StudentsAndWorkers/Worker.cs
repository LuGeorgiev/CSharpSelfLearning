using System;


namespace StudentsAndWorkers
{
    class Worker:Human,IHuman,IWorker
    {        
        private decimal weeklySalary;
        private decimal workHoursPerDay;

        
        public decimal WeeklySalary
        {
            get
            {
                return this.weeklySalary;
            }
            private set
            {
                if (value<=0)
                {
                    throw new NullReferenceException("Weekly Salary ahve to be greater than 0");
                }
                else
                {
                    this.weeklySalary = value;
                }
            }
        }
        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new NullReferenceException("Weekly hours per day have to be greater than 0");
                }
                else
                {
                    this.workHoursPerDay = value;
                }
            }
        }
        

        public Worker(string first, string last, decimal weekSal, decimal hoursPerDAy):base(first,last)
        {           
            this.WeeklySalary = weekSal;
            this.WorkHoursPerDay = hoursPerDAy;            
        }

        public decimal MoneyPerHour()
        {
            return (this.WeeklySalary / (this.WorkHoursPerDay * 5));
        }
    }
}
