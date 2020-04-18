using FluentAssertions;
using TaxCalculator.Services.Validation.Implementation;
using Xunit;

namespace TaxCalculator.Tests.Services.Validation
{
    public class SalaryValidationTests
    {
        [Theory]
        [InlineData("wrong")]
        [InlineData("123,3434")]
        [InlineData("123-")]
        public void IsValidShouldReturnFalseIfInputIsInvalidString(string salaryToTest)
        {
            var salaryValidation = new SalaryValidationService();

            var result = salaryValidation.IsValid(salaryToTest);

            result
                .Should()
                .BeFalse();
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        public void IsValidShouldReturnFalseIfInputIsNegativeString(string salaryToTest)
        {
            var salaryValidation = new SalaryValidationService();

            var result = salaryValidation.IsValid(salaryToTest);

            result
                .Should()
                .BeFalse();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("123.3434")]
        [InlineData("123234234234234")]
        public void IsValidShouldReturnTrueIfInputIsValidPositiveString(string salaryToTest)
        {
            var salaryValidation = new SalaryValidationService();

            var result = salaryValidation.IsValid(salaryToTest);

            result
                .Should()
                .BeTrue();
        }
    }
}
