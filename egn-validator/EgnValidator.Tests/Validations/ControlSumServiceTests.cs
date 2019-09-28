using Xunit;
using FluentAssertions;
using EgnValidator.Services.Validations.Implementations;

namespace EgnValidator.Tests.Validations
{
    public class ControlSumServiceTests
    {
        
        [Theory]
        [InlineData("7811167244")]
        [InlineData("0852306253")]
        [InlineData("1050126620")]
        [InlineData("0549066285")]
        public void ControlSumService_True_IfEgnIsCorrect(string egnToTest)
        {            
            var controlSumService = new ControlSumService();

            var result = controlSumService.IsSumValid(egnToTest);

            result
                .Should()
                .BeTrue();
        }

        [Theory]
        [InlineData("7811167243")]
        [InlineData("0852306233")]
        [InlineData("1050126720")]
        [InlineData("0549066185")]
        public void ControlSumService_False_IfEgnIsNotCorrect(string egnToTest)
        {
            var controlSumService = new ControlSumService();

            var result = controlSumService.IsSumValid(egnToTest);

            result
                .Should()
                .BeFalse();
        }

    }
}
