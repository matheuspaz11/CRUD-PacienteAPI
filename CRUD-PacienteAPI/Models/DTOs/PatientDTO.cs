using CRUD_PacienteAPI.Helpers.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUD_PacienteAPI.Models.DTOs
{
    public class PatientDTO
    {
        [Required(ErrorMessage = "O campo Name é obrigatório")]
        [ValidateString]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo DateBirth é obrigatório")]
        [JsonPropertyName("DateBirth")]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "O campo TaxNumber é obrigatório")]
        [JsonPropertyName("TaxNumber")]
        public string TaxNumber { get; set; }

        [Required(ErrorMessage = "O campo SexualGender é obrigatório")]
        [JsonPropertyName("SexualGender")]
        public int SexualGender { get; set; }

        [JsonPropertyName("Address")]
        public AddressDTO? Address { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório")]
        [JsonPropertyName("Status")]
        public int Status { get; set; }
    }
}