using System.ComponentModel.DataAnnotations;

namespace CRUD_PacienteAPI.Helpers.Validators
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string[] format = { "dd-MM-yyyy" };

                if (DateTime.TryParseExact(value.ToString(), format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("O campo DateBirth não está no padrão correto.");
            }else
                return ValidationResult.Success;
        }
    }
}