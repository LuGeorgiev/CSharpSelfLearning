using System;

namespace EstateManagment.Web.Common.Extensions
{
    public static class DateExtension
    {
        public static string DateBgFormat(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}
