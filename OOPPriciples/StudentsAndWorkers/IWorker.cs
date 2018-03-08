

namespace StudentsAndWorkers
{
    interface IWorker
    {
        decimal WeeklySalary { get; }
        decimal WorkHoursPerDay { get; }
        decimal MoneyPerHour();
    }
}
