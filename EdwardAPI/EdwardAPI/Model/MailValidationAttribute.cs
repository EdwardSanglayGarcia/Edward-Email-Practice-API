namespace EdwardAPI.Model
{
    using System.ComponentModel.DataAnnotations;
    public class MailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var mail = validationContext.ObjectInstance as Mail;
            if (mail?.Membership?.ToLower() == "trial")
            {
                return new ValidationResult("NOT VALID THIS IS FOR NON TRIAL USERS ONLY!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
