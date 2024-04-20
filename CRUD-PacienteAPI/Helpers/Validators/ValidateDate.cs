using System.ComponentModel.DataAnnotations;

namespace CRUD_PacienteAPI.Helpers.Validators
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] validDate = { "yyyy-MM-dd", "dd-MM-yyyy" };

            foreach (string format in validDate)
            {
                if (DateTime.TryParseExact(value.ToString(), format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("O campo DateBirth não está no padrão correto.");
        }
    }
}