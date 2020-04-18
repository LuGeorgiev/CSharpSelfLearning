using System;
using TaxCalculator.BusinessLogic;
using TaxCalculator.Services.Infrastructure;
using TaxCalculator.Services.InputOutput;

using static TaxCalculator.Constants.Constants;

namespace TaxCalculator
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISalaryCalculator salaryCalculator;
        private readonly IDateService dateService;

        public Engine(IWriter writer, IReader reader, ISalaryCalculator salaryCalculator, IDateService dateService)
        {
            this.reader = reader;
            this.writer = writer;
            this.salaryCalculator = salaryCalculator;
            this.dateService = dateService;
        }

        public void Run()
        {
            this.writer.WriteLine(EngineConstants.GREETING_MESSAGE);
            var salaryString = this.reader.ReadLine();

            while (salaryString.ToLower() != EngineConstants.QUIT_MESSAGE)
            {
                var netSalary = this.salaryCalculator.CalculateNetSalary(salaryString);

                if (netSalary == EngineConstants.INVALID_SALARY)
                {
                    this.writer.WriteLine(EngineConstants.INVALID_SALARY_MESSAGE + Environment.NewLine);
                }
                else
                {
                    this.writer.WriteLine(String.Format(EngineConstants.SALARY_MESSAGE, 
                                                            netSalary, 
                                                            this.dateService.Now() ));

                    this.writer.WriteLine(EngineConstants.ANOTHER_SALARY_MESSAGE + Environment.NewLine);
                }

                salaryString = this.reader.ReadLine();
            }
        }
    }
}
