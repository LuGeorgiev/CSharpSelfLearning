using Xunit;
using FluentAssertions;
using Moq;
using EgnValidator.Tests.Mocks;
using System;
using EgnValidator.Services.Validations.Implementations;
using EgnValidator.Services.Infrastructure;

namespace EgnValidator.Tests.Validations
{
    public class FutureDateServiceTests
    {
        [Fact]
        public void FutureService_False_IfEgnDateIsInPast()
        {
            var dateTimeProvider = DateTimeProviderMock.New;
            dateTimeProvider
                .Setup(x => x.BgNow())
                .Returns(new DateTime(2019, 12, 12));

            var dateTotest = new DateTime(2000, 12, 12);
            var futureDateService = new FutureDateService(dateTimeProvider.Object);

            var result = futureDateService.IsDateInFuture(dateTotest);

            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void FutureService_True_IfEgnDateIsInFuture()
        {
            var dateTimeProvider = DateTimeProviderMock.New;
            dateTimeProvider
                .Setup(x => x.BgNow())
                .Returns(new DateTime(2019, 12, 12));

            var dateTotest = new DateTime(2030, 12, 12);
            var futureDateService = new FutureDateService(dateTimeProvider.Object);

            var result = futureDateService.IsDateInFuture(dateTotest);

            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void FutureService_False_IfEgnDateIsOnDateTimeNow()
        {
            var dateTimeProvider = DateTimeProviderMock.New;
            dateTimeProvider
                .Setup(x => x.BgNow())
                .Returns(new DateTime(2019, 12, 12));

            var dateTotest = new DateTime(2019, 12, 12);
            var futureDateService = new FutureDateService(dateTimeProvider.Object);

            var result = futureDateService.IsDateInFuture(dateTotest);

            result
                .Should()
                .BeFalse();
        }
    }
}
