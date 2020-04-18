using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.BusinessLogic
{
    public interface ISalaryCalculator
    {
        decimal CalculateNetSalary(decimal grossSalary);
    }
}
