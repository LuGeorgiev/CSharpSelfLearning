using System.Text.RegularExpressions;

namespace LearningSystem.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
        {
            return Regex.Replace(text, @"[^A-Za-z0-9_\.~]+","-").ToLower();
        }
    }
}
