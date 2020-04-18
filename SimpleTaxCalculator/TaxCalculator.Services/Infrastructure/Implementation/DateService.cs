using System;

namespace TaxCalculator.Services.Infrastructure.Implementation
{
    public class DateService : IDateService
    {
        public DateTime Now()
            => DateTime.Now;

        public DateTime UtcNow()
            => DateTime.UtcNow;
    }
}
