using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class FutureDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTimeValue)
            {
                if (dateTimeValue < DateTime.Today)
                {
                    return new ValidationResult("The date must be today or a future date.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
