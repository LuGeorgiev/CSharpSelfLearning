using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstateManagment.Data.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class XorAttributte : ValidationAttribute
    {
        private string xorTargetAttribute;

        public XorAttributte(string xorTargetAttribute)
        {
            this.xorTargetAttribute = xorTargetAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetAttribute = validationContext.ObjectType
                .GetProperty(xorTargetAttribute)
                .GetValue(validationContext.ObjectInstance);

            if (targetAttribute == null ^ value == null)
            {
                return ValidationResult.Success;
            }

            string errorMsg = "One of the property have to ne null!";
            return new ValidationResult(errorMsg);
        }
    }
}
