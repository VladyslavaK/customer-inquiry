using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class DigitsLengthAttribute: ValidationAttribute
    {
        private readonly int _digitsNumber;
        public DigitsLengthAttribute(int digitsNumber)
        {
            _digitsNumber = digitsNumber;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var isNumber = value is long;
                if (isNumber)
                {
                    return value.ToString().Length == _digitsNumber ? ValidationResult.Success
                        : new ValidationResult($"Invalid {validationContext.MemberName}. Expected {_digitsNumber} digits");
                }

                return new ValidationResult($"Invalid {validationContext.MemberName}");
            }
            return null;
        }
    }
}
