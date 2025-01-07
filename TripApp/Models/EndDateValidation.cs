using System.ComponentModel.DataAnnotations;

namespace Anetia_TripApp.Models
{
    public class EndDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is Page1ViewModel pageModel)
            {
                if (pageModel.EndDate < pageModel.StartDate)
                {
                    return new ValidationResult("End Date must be greater than or equal to Start Date.");
                }
            }
            else if (validationContext.ObjectInstance is Trip tripModel)
            {
                if (tripModel.EndDate < tripModel.StartDate)
                {
                    return new ValidationResult("End Date must be greater than or equal to Start Date.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
