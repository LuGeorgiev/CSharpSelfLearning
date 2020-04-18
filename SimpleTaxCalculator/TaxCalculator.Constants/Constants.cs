
namespace TaxCalculator.Constants
{
    public static class Constants
    {
        public class EngineConstants 
        {
            public const string GREETING_MESSAGE = "Please, insert your gross salary or type \"quit\" to exit!";
            public const string ANOTHER_SALARY_MESSAGE = "Please, insert another gross salary to calculate or type \"quit\" to exit!";
            public const string QUIT_MESSAGE = "quit";
            public const string INVALID_SALARY_MESSAGE = "Please, insert valid positive salary or type \"quit\" to exit!";
            public const string SALARY_MESSAGE = "Your net salary should be: {0:F2} as of {1}";

            public const decimal INVALID_SALARY = -1;
        }

        public class SalaryConstants
        {
            public const decimal INVALID_SALARY_CODE = -1;
            public const decimal MINIMUM_SALARY = 0;
            public const decimal NO_TAX_LIMIT = 1000;
            public const decimal MAX_SOCIAL_LIMIT = 3000;
            public const decimal INCOME_TAX = 0.1m;
            public const decimal Social_TAX = 0.15m;
        }
    }
}
