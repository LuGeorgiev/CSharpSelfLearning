﻿

namespace CamaraBazar.Web.Infrastricture.Extensions
{
    using CamaraBazar.Data.Models;

    public static class EnumExtensions
    {
        public static string ToDisplayName(this LightMetering lightMetering)
        {
            if (lightMetering== LightMetering.CenterWeighted)
            {
                return "Center-Weighted";
            }

            return lightMetering.ToString();
        }
    }
}
