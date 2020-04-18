using Moq;
using TaxCalculator.Services.Validation;

namespace TaxCalculator.Tests.Mocks
{
    public class SalaryValidationServiceMock
    {
        public static Mock<ISalaryValidationService> New
            => new Mock<ISalaryValidationService>();
    }
}
