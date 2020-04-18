using Moq;
using TaxCalculator.Services.TaxCalculation;

namespace TaxCalculator.Tests.Mocks
{
    public class TaxCalculatorServiceMock
    {
        public static Mock<ITaxesCalculatorService> New
            => new Mock<ITaxesCalculatorService>();
    }
}
