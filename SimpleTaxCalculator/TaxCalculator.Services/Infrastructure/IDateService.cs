using System;

namespace TaxCalculator.Services.Infrastructure
{
    public interface IDateService
    {
        DateTime Now();

        DateTime UtcNow();
    }
}
