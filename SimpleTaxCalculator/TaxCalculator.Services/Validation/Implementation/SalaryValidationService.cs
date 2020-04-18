using System;

using static TaxCalculator.Constants.Constants;

namespace TaxCalculator.Services.Validation.Implementation
{
    public class SalaryValidationService : ISalaryValidationService
    {
        public bool IsValid(string salaryString)
            => Decimal.TryParse(salaryString, out decimal salary) 
                && salary > SalaryConstants.MINIMUM_SALARY ;
       
    }
}
