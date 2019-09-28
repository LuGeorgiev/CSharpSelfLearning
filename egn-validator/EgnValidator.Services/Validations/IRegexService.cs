namespace EgnValidator.Services.Validations
{
    public interface IRegexService
    {
        bool IsStringValid(string egn, string pattern);
    }
}
