using EgnValidator.Services.Infrastructure;
using System;

namespace EgnValidator.Services.Validations.Implementations
{
    public class FutureDateService : IFutureDateService
    {
        private readonly IDateTimeProvider dateProvider;

        public FutureDateService(IDateTimeProvider dateProvider)
        {
            this.dateProvider = dateProvider;
        }

        //It is needed to compare with next day because ot time difference 
        public bool IsDateInFuture(DateTime egnDate)
            => this.dateProvider.BgNow().AddDays(1).Date < egnDate.Date;
    }
}
