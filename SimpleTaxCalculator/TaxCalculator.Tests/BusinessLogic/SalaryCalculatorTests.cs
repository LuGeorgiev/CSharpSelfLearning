using FluentAssertions;
using TaxCalculator.BusinessLogic;
using TaxCalculator.Tests.Mocks;
using Xunit;

using static TaxCalculator.Constants.Constants;

namespace TaxCalculator.Tests.BusinessLogic
{
    public class SalaryCalculatorTests
    {
        [Fact]
        public void SalaryCalculatorShouldReturnInvalidCodeWhenSalaryIsNotValid()
        {
            var salaryString = "-1";
            var salaryValidation = SalaryValidationServiceMock.New;
            salaryValidation
                .Setup(x => x.IsValid(salaryString))
                .Returns(false);
            var salaryCalculator = new SalaryCalculator(null, salaryValidation.Object);

            var result = salaryCalculator.CalculateNetSalary(salaryString);

            result
                .Should()
                .Be(SalaryConstants.INVALID_SALARY_CODE);
        }

        [Fact]
        public void SalaryCalculatorShouldNotReturnInvalidCodeWhenSalaryIsValid()
        {
            var salaryString = "1";
            var grossSalary = 1m;
            var taxesCalculator = TaxCalculatorServiceMock.New;
            taxesCalculator
                .Setup(x => x.ShouldApplyTax(grossSalary))
                .Returns(false);
            var salaryValidation = SalaryValidationServiceMock.New;
            salaryValidation
                .Setup(x => x.IsValid(salaryString))
                .Returns(true);
            var salaryCalculator = new SalaryCalculator(taxesCalculator.Object, salaryValidation.Object);

            var result = salaryCalculator.CalculateNetSalary(salaryString);

            result
                .Should()
                .NotBe(SalaryConstants.INVALID_SALARY_CODE);
        }

        [Fact]
        public void SalaryCalculatorShouldReturnCorrectValue()
        {
            var salaryString = "3400";
            var grossSalary = 3400m;
            var taxesCalculator = TaxCalculatorServiceMock.New;
            taxesCalculator
                .Setup(x => x.ShouldApplyTax(grossSalary))
                .Returns(true);
            taxesCalculator
               .Setup(x => x.IncomeTax(grossSalary))
               .Returns(240);
            taxesCalculator
               .Setup(x => x.SocialTax(grossSalary))
               .Returns(300);
            var salaryValidation = SalaryValidationServiceMock.New;
            salaryValidation
                .Setup(x => x.IsValid(salaryString))
                .Returns(true);
            var salaryCalculator = new SalaryCalculator(taxesCalculator.Object, salaryValidation.Object);

            var result = salaryCalculator.CalculateNetSalary(salaryString);

            result
                .Should()
                .Be(2860);
        }
    }
}
