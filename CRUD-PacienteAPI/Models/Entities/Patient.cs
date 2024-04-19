using static CRUD_PacienteAPI.Models.Enums.Enum;

namespace CRUD_PacienteAPI.Models.Entities
{
    public class Patient
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public long TaxNumber { get; set; }

        public SexualGender SexualGender { get; set; }

        public Address Address { get; set; }

        public PatientStatus Status { get; set; }
    }
}
