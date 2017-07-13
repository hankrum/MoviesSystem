using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MS.Models
{
    public class ValidationMethods
    {
        public static ValidationResult ValidateLessThanNow(DateTime value, ValidationContext context)
        {
            bool isValid = true;

            if (value > DateTime.Now)
            {
                isValid = false;
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(
                    string.Format("The field {0} cannot be future value.", context.MemberName),
                    new List<string>() { context.MemberName });
            }
        }
    }
}
