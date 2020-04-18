using static TaxCalculator.Constants.Constants;

namespace TaxCalculator.Services.TaxCalculation.Implementation
{
    public class TaxesCalculatorService : ITaxesCalculatorService
    {
        public decimal IncomeTax(decimal salary)
        {
            decimal sumToApplyIncomeTax = ReduceFreeOfTaxSum(salary);

            return sumToApplyIncomeTax * SalaryConstants.INCOME_TAX;
        }

        

        public bool ShouldApplyTax(decimal grossSalary)
            => grossSalary > SalaryConstants.NO_TAX_LIMIT;

        public decimal SocialTax(decimal salary)
        {
            if (salary > SalaryConstants.MAX_SOCIAL_LIMIT)
            {
                salary = SalaryConstants.MAX_SOCIAL_LIMIT;
            }

            decimal sumToApplySocialTax = ReduceFreeOfTaxSum(salary);

            return sumToApplySocialTax * SalaryConstants.Social_TAX;
        }


        private  decimal ReduceFreeOfTaxSum(decimal salary)
            =>salary - SalaryConstants.NO_TAX_LIMIT;
    }
}
