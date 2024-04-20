namespace CRUD_PacienteAPI.Models.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public int HouseNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
