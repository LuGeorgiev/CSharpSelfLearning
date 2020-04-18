using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Services.TaxCalculation
{
    public interface ITaxesCalculator
    {
        decimal IncomeTax(decimal salary);

        decimal SocialTax(decimal salary);
        bool ShouldApplyTax(decimal grossSalary);
    }
}
