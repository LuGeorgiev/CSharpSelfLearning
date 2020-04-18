using System;
using TaxCalculator.Services.TaxCalculation;
using TaxCalculator.Services.Validation;

using static TaxCalculator.Constants.Constants;

namespace TaxCalculator.BusinessLogic
{
    public class SalaryCalculator : ISalaryCalculator
    {
        private readonly ITaxesCalculator taxesCalculator;
        private readonly ISalaryValidation salaryValidation;

        public SalaryCalculator(ITaxesCalculator taxesCalculator, ISalaryValidation salaryValidation)
        {
            this.taxesCalculator = taxesCalculator;
            this.salaryValidation = salaryValidation;
        }

        public decimal CalculateNetSalary(string grossSalaryString)
        {
            if (! this.salaryValidation.IsValid(grossSalaryString))
            {
                return SalaryConstants.INVALID_SALARY_CODE;
            }

            var grossSalary = Decimal.Parse(grossSalaryString);

            if (! this.taxesCalculator.ShouldApplyTax(grossSalary))
            {
                return grossSalary;
            }

            var incomeTax = this.taxesCalculator.IncomeTax(grossSalary);
            var socialTax = this.taxesCalculator.SocialTax(grossSalary);

            return grossSalary - incomeTax - socialTax;
        }
    }
}
