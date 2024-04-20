using System.Text.Json.Serialization;

namespace CRUD_PacienteAPI.Models.DTOs
{
    public class AddressDTO
    {
        [JsonPropertyName("Street")]
        public string Street { get; set; }

        [JsonPropertyName("Neighborhood")]
        public string Neighborhood { get; set; }

        [JsonPropertyName("HouseNumber")]
        public int HouseNumber { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("Estate")]
        public string Estate { get; set; }
    }
}