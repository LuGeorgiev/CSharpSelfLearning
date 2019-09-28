using EgnValidator.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services.Validations.Implementations
{
    public class DateService : IDateService
    {
        private readonly IExtractDate dateExtractor;
        private readonly IFutureDateService futureServica;

        public DateService(IExtractDate dateExtractor, IFutureDateService futureServica)
        {
            this.dateExtractor = dateExtractor;
            this.futureServica = futureServica;
        }

        /// <summary>
        /// Will return false for invalid or dates in future
        /// </summary>
        /// <param name="egn">EGN string</param>
        /// <returns>TRUE if date is valid AND in past</returns>
        public bool IsEgnDateValid(string egn)
        {
            var egnDate = this.dateExtractor.TryExtractDate(egn);

            if (egnDate == null)
            {
                //Date is INVALID
                return false;
            }

            if (this.futureServica.IsDateInFuture(egnDate.Value))
            {
                //EGN date is in future
                return false;
            }

            return true ;                       
        }
    }
}
