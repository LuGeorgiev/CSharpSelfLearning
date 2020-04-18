using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Services.TaxCalculation.Implementation;
using Xunit;

using static TaxCalculator.Constants.Constants;

namespace TaxCalculator.Tests.Services.TaxCalculation
{
    public class TasCalculatorServiceTests
    {
        [Fact]
        public void IncomeTaxShouldReturnCorrectValue()
        {
            var taxCalculatorService = new TaxesCalculatorService();
            var salaryToTest = 1100m;
            var incomeTax = (salaryToTest - SalaryConstants.NO_TAX_LIMIT) * SalaryConstants.INCOME_TAX;            

            var result = taxCalculatorService.IncomeTax(salaryToTest);

            result
                .Should()
                .Be(incomeTax);
        }

        [Fact]
        public void ShouldApplyTaxShouldReturnTrueIfHigherThanTaxLimit()
        {
            var taxCalculatorService = new TaxesCalculatorService();
            var salaryToTest = SalaryConstants.NO_TAX_LIMIT + 1;

            var result = taxCalculatorService.ShouldApplyTax(salaryToTest);

            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ShouldApplyTaxShouldReturnFaseIfLowerThanTaxLimit()
        {
            var taxCalculatorService = new TaxesCalculatorService();
            var salaryToTest = SalaryConstants.NO_TAX_LIMIT - 1;

            var result = taxCalculatorService.ShouldApplyTax(salaryToTest);

            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void SocialTaxShouldReturnCorrectIfBelowSocialLimit()
        {
            var taxCalculatorService = new TaxesCalculatorService();
            var salaryToTest = 1100m;
            var incomeTax = (salaryToTest - SalaryConstants.NO_TAX_LIMIT) * SalaryConstants.Social_TAX;

            var result = taxCalculatorService.SocialTax(salaryToTest);

            result
                .Should()
                .Be(incomeTax);
        }

        [Fact]
        public void SocialTaxShouldReturnCorrectIfAboveSocialLimit()
        {
            var taxCalculatorService = new TaxesCalculatorService();
            var salaryToTest = 3400m;
            var incomeTax = 300m;

            var result = taxCalculatorService.SocialTax(salaryToTest);

            result
                .Should()
                .Be(incomeTax);
        }
    }
}
