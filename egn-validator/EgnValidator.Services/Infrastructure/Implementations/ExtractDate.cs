using System;

using static EgnValidator.Constants.Global;

namespace EgnValidator.Services.Infrastructure.Implementations
{
    public class ExtractDate : IExtractDate
    {
        public DateTime? TryExtractDate(string dateString)
        {
            var dateSubstring = dateString.Substring(0, EGN_DATE_LENGTH);

            var egnYearStr = dateString.Substring(0, 2);
            var egnMonthStr = dateString.Substring(2, 2);
            var egnDayStr = dateString.Substring(4, 2);

            //var egnYear = Int16.Parse(egnYearStr);
            //var egnMonth = Int16.Parse(egnMonthStr);
            //var egnDay = Int16.Parse(egnDayStr);
            var dateToValidate = 

            var isDateValid = DateTime.TryParse

            return null;
        }
    }
}
