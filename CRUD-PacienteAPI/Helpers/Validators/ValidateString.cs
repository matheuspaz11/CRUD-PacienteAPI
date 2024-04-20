using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CRUD_PacienteAPI.Helpers.Validators
{
    public class ValidateString : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string text = value.ToString();

                if (!Regex.IsMatch(text, @"^[a-zA-Z ]+$"))
                {
                    return new ValidationResult("O campo Name não pode conter caracteres especiais ou números.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
