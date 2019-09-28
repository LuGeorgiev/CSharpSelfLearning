using System;
using System.Globalization;
using static EgnValidator.Constants.Global;

namespace EgnValidator.Services.Infrastructure.Implementations
{
    public class ExtractDate : IExtractDate
    {
        public DateTime? TryExtractDate(string dateString)
        {
            var egnYearStr = dateString.Substring(0, 2);
            var egnMonthStr = dateString.Substring(2, 2);
            var egnDayStr = dateString.Substring(4, 2);
            var dateToValidate = "";

            if (egnMonthStr[0] == '0' || egnMonthStr[0] == '1')
            {
                //Date is between 1900 - 1999 year
                dateToValidate = $"{egnDayStr}/{egnMonthStr}/19{egnYearStr}";
            }
            else if (egnMonthStr[0] == '2')// Year 1800-1899
            {
                egnMonthStr = $"0{egnMonthStr[1]}"; // month from 01 to 09
                dateToValidate = $"{egnDayStr}/{egnMonthStr}/18{egnYearStr}";
            }
            else if (egnMonthStr[0] == '3')// Year 1800-1899
            {
                egnMonthStr = $"1{egnMonthStr[1]}"; // month from 10 to 12
                dateToValidate = $"{egnDayStr}/{egnMonthStr}/18{egnYearStr}";
            }
            else if (egnMonthStr[0] == '4')// Year 2000-2099
            {
                egnMonthStr = $"0{egnMonthStr[1]}"; // month from 01 to 09
                dateToValidate = $"{egnDayStr}/{egnMonthStr}/20{egnYearStr}";
            }
            else if (egnMonthStr[0] == '5')// Year 2000-2099
            {
                egnMonthStr = $"1{egnMonthStr[1]}"; // month from 10 to 12
                dateToValidate = $"{egnDayStr}/{egnMonthStr}/20{egnYearStr}";
            }

            DateTime resultDate;
            
            var isDateValid = DateTime.TryParse(dateToValidate, out resultDate);

            if (isDateValid)
            {
                return resultDate;
            }

            return null;
        }
    }
}
