using EgnValidator.Services.Validations.Implementations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EgnValidator.Tests.Validations
{
    public class LeapYearTests
    {
        [Fact]
        public void LeapYear_ThorwNotImplemented_Always()
        {
            var egnToTest = "1212121212";
            var leapeYear = new LeapYearService();


            leapeYear.Invoking(x => x.IsYearLeap(egnToTest))
                .Should()
                .Throw<NotImplementedException>();
        }
    }
}
