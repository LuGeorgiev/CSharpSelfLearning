using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        private const string NumberFormat = "F2";
        public static string ToPrice(this decimal price)
        {
            return $"${ price.ToString(NumberFormat)}";
        }

        public static string ToPrice(this double price)
        {
            return $"${ price.ToString(NumberFormat)}";
        }

        public static string ToPercentage(this double number)
        {
            return $"{ number.ToString(NumberFormat)}%";
        }
    }
}
