using System.Text.RegularExpressions;

namespace EgnValidator.Services.Validations.Implementations
{
    public class RegexService : IRegexService
    {
        public bool IsStringValid(string egn, string pattern)
        {
            var regex = new Regex(pattern);

            return regex.IsMatch(egn);
        }
    }
}
