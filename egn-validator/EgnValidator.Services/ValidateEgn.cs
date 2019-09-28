using EgnValidator.Services.Validations;
using System;

using static EgnValidator.Constants.Global;

namespace EgnValidator.Services
{
    public class ValidateEgn : IValidateEgn
    {
        private readonly IRegexService regexValidate;
        private readonly IDateService dateValidation;
        private readonly IControlSum controlSumService;

        public ValidateEgn(IRegexService regexValidate, IDateService dateValidation, IControlSum controlSumService)
        {
            this.regexValidate = regexValidate;
            this.dateValidation = dateValidation;
            this.controlSumService = controlSumService;
        }

        public string IsValid(string egn)
        {
            if (!this.regexValidate.IsStringValid(egn, PATTERN))
            {
                return INVALID_REGEX;
            }
            else if (!this.dateValidation.IsEgnDateValid(egn))
            {
                return INVALID_DATE;
            }
            else if (!this.controlSumService.IsSumValid(egn))
            {
                return INVALID_CONTROL_SUM;
            }

            return VALID_ID;
        }
    }
}
