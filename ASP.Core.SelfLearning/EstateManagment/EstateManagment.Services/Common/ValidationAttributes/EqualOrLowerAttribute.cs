using System;
using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Services.Common.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =true)]
    public class EqualOrLowerAttribute : ValidationAttribute
    {
        
        private string compareAttribute;
        public EqualOrLowerAttribute(string compareAttribute)
        {
            this.compareAttribute = compareAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetAttribute = validationContext
                .ObjectType
                .GetProperty(compareAttribute)
                .GetValue(validationContext.ObjectInstance)
                .ToString();

            if (decimal.TryParse(targetAttribute, out var target)&& 
                decimal.TryParse(value.ToString(), out var input)&&
                input>=0 &&
                input<=target)
            {
                return ValidationResult.Success;
            }


            string errorMessagePayment = "Плащането трябва да е положитено и НЕ по-голямо от дължимата сума";

            return new ValidationResult(errorMessagePayment);
        }

    }
}
