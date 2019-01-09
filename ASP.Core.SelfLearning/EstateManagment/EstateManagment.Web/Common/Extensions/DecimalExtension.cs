using System.Globalization;

namespace EstateManagment.Web.Common.Extensions
{
    public static class DecimalExtension
    {
        public static string ThousandsSeparate(this decimal money)
        {
            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";
            return money.ToString("#,0.00", nfi);
        }
    }
}
