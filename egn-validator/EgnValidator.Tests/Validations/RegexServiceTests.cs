using EgnValidator.Services.Validations.Implementations;
using FluentAssertions;
using Xunit;

using static EgnValidator.Constants.Global;

namespace EgnValidator.Tests.Validations
{
    public class RegexServiceTests
    {
        [Fact]
        public void RegexService_False_IfAnyLetteraInString()
        {
            var egnToTest = "8114523A66";
            var regexService = new RegexService();

            var result = regexService.IsStringValid(egnToTest, PATTERN);

            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void RegexService_False_IfLengthLowerThanTen()
        {
            var egnToTest = "78451236";
            var regexService = new RegexService();

            var result = regexService.IsStringValid(egnToTest, PATTERN);

            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void RegexService_False_IfLengthBiggerThanTen()
        {
            var egnToTest = "784578781236";
            var regexService = new RegexService();

            var result = regexService.IsStringValid(egnToTest, PATTERN);

            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void RegexService_False_IfMonthBiggerFiftyNine()
        {
            var egnToTest = "7860167244";
            var regexService = new RegexService();

            var result = regexService.IsStringValid(egnToTest, PATTERN);

            result
                .Should()
                .BeFalse();
        }


        [Fact]
        public void RegexService_True_IfTenValidDigitsPassed()
        {
            var egnToTest = "7811167244";
            var regexService = new RegexService();

            var result = regexService.IsStringValid(egnToTest, PATTERN);

            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void RegexService_False_IfTenInvalidDigitsPassed()
        {
            var egnToTest = "9999999999";
            var regexService = new RegexService();

            var result = regexService.IsStringValid(egnToTest, PATTERN);

            result
                .Should()
                .BeFalse();
        }
    }
}
