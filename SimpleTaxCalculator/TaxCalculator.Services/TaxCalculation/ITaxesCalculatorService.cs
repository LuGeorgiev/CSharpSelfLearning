using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Services.TaxCalculation
{
    public interface ITaxesCalculatorService
    {
        decimal IncomeTax(decimal salary);

        decimal SocialTax(decimal salary);
        bool ShouldApplyTax(decimal grossSalary);
    }
}
