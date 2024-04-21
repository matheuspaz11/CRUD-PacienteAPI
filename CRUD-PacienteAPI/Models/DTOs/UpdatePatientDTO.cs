using CRUD_PacienteAPI.Helpers.Validators;
using System.Text.Json.Serialization;

namespace CRUD_PacienteAPI.Models.DTOs
{
    public class UpdatePatientDTO
    {
        [ValidateString]
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [ValidateDate]
        [JsonPropertyName("DateBirth")]
        public string? DateBirth { get; set; }

        [JsonPropertyName("TaxNumber")]
        public string? TaxNumber { get; set; }

        [JsonPropertyName("SexualGender")]
        public int? SexualGender { get; set; }

        [JsonPropertyName("Address")]
        public AddressDTO? Address { get; set; }

        [JsonPropertyName("Status")]
        public int? Status { get; set; }
    }
}
