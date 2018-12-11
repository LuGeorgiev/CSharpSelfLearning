using System;
using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Services.Common.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AfterDateAttribute : ValidationAttribute
    {
        private string compareAttribute;
        public AfterDateAttribute(string compareAttribute)
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

            if (DateTime.TryParse(targetAttribute, out var target) &&
                DateTime.TryParse(value.ToString(), out var input) &&                
                input > target)
            {
                return ValidationResult.Success;
            }


            string errorMessagePayment = "Крайната дата трябва да е преди началната";

            return new ValidationResult(errorMessagePayment);
        }
    }
}
