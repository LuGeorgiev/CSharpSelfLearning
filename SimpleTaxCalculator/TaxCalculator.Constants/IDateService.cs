using System;

namespace TaxCalculator.Constants
{
    public interface IDateService
    {
        DateTime Now();

        DateTime UtcNow();
    }
}
