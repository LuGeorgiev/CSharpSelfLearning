using System;

namespace EgnValidator.Services.Infrastructure.Implementations
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime BgNow()
            => DateTime.Now;

        public DateTime UtcNow()
            => DateTime.UtcNow;
    }
}
