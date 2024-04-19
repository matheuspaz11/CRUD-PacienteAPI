using System.Text.Json.Serialization;

namespace CRUD_PacienteAPI.Models.DTOs
{
    public class PatientDTO
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("DateBirth")]
        public DateTime DateBirth { get; set; }

        [JsonPropertyName("TaxNumber")]
        public long TaxNumber { get; set; }

        [JsonPropertyName("SexualGender")]
        public int SexualGender { get; set; }

        [JsonPropertyName("Address")]
        public AddressDTO Address { get; set; }

        [JsonPropertyName("Status")]
        public int Status { get; set; }
    }
}