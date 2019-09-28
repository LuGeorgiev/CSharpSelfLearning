using EgnValidator.Services.Infrastructure;
using EgnValidator.Services.Infrastructure.Implementations;
using Moq;

namespace EgnValidator.Tests.Mocks
{
    public class DateTimeProviderMock
    {
        public static Mock<IDateTimeProvider> New
            => new Mock<IDateTimeProvider>();
    }
}
