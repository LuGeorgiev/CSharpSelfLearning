using Xunit;
using FluentAssertions;
using System;
using EgnValidator.Services.Infrastructure.Implementations;

namespace EgnValidator.Tests.Infrastructure
{
    public class ExtractDateTests
    {
        [Theory]
        [InlineData("7811161111")]
        [InlineData("2002291111")]
        [InlineData("0852301111")]
        [InlineData("1050121111")]
        [InlineData("0549061111")]
        public void ExtractDate_NotNull_WhenEgnDAteIsValid(string egnToTest)
        {
            var extractDate = new ExtractDate();

            var result = extractDate.TryExtractDate(egnToTest);

            result
                .Should()
                .NotBeNull();
        }

        [Theory]
        [InlineData("7813161111")]
        [InlineData("1902291111")]
        [InlineData("1050321111")]
        [InlineData("0569061111")]
        public void ExtractDate_Null_WhenEgnIsValid(string egnToTest)
        {
            var extractDate = new ExtractDate();

            var result = extractDate.TryExtractDate(egnToTest);

            result
                .Should()
                .BeNull();
        }

        [Fact]
        public void ExtractDate_ExactDate_WhenEgnIsValid_Between1900_1999()
        {
            var egnToTest = "7811161111";
            var extractDate = new ExtractDate();

            var result = extractDate.TryExtractDate(egnToTest);

            result
                .Should()
                .Be(new DateTime(1978, 11, 16));
        }

        [Fact]
        public void ExtractDate_ExactDate_WhenEgnIsValid_Between1800_1899()
        {
            var egnToTest = "7821161111";
            var extractDate = new ExtractDate();

            var result = extractDate.TryExtractDate(egnToTest);

            result
                .Should()
                .Be(new DateTime(1878, 01, 16));
        }

        [Fact]
        public void ExtractDate_ExactDate_WhenEgnIsValid_Between1800_1899_LastTWoMonths()
        {
            var egnToTest = "7831161111";
            var extractDate = new ExtractDate();

            var result = extractDate.TryExtractDate(egnToTest);

            result
                .Should()
                .Be(new DateTime(1878, 11, 16));
        }

        [Fact]
        public void ExtractDate_ExactDate_WhenEgnIsValid_After2000()
        {
            var egnToTest = "7841161111";
            var extractDate = new ExtractDate();

            var result = extractDate.TryExtractDate(egnToTest);

            result
                .Should()
                .Be(new DateTime(2078, 01, 16));
        }

        [Fact]
        public void ExtractDate_ExactDate_WhenEgnIsValid_After2000_LastTwoMonths()
        {
            var egnToTest = "7851161111";
            var extractDate = new ExtractDate();

            var result = extractDate.TryExtractDate(egnToTest);

            result
                .Should()
                .Be(new DateTime(2078, 11, 16));
        }
    }
}
