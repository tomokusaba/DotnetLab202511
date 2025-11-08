using System.ComponentModel.DataAnnotations;

namespace DotnetLab202203.CustomValidate
{
    public class BirthDayValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                var dateValue = (DateTime)value;
                if (dateValue < DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            throw new ArgumentException("引数の型が違います", nameof(value));
        }
    }
}
