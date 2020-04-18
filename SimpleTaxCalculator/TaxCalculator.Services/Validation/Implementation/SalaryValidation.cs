using System;

using static TaxCalculator.Constants.Constants;

namespace TaxCalculator.Services.Validation.Implementation
{
    public class SalaryValidation : ISalaryValidation
    {
        public bool IsValid(string salaryString)
            => Decimal.TryParse(salaryString, out decimal salary) 
                && salary > SalaryConstants.MINIMUM_SALARY ;
       
    }
}
