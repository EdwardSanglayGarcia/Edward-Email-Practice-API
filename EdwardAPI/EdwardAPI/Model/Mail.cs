using System.ComponentModel.DataAnnotations;

namespace EdwardAPI.Model
{
    public class Mail : IValidatableObject
    {
        public int Id { get; set; } 
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        public string? Header { get; set; }  

        [Required(AllowEmptyStrings = true)]
        public string? Body { get; set; }
        public DateTime Created { get; set; } = DateTime.Now.ToUniversalTime();

        [Required]
        [Phone(ErrorMessage = "Phone Number is not valid!")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(18,99, ErrorMessage = "Please Enter a valid age 18-99")]
        public int Age { get; set; }

        [MailValidation]
        public string Membership { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if the date is less than 2022 -> throw an error
            if (Created.Year < 2022)
            {
                yield return new ValidationResult("Date is Incorrect!");//ienumerable kaya yielf return
            }
        }
    }
}
