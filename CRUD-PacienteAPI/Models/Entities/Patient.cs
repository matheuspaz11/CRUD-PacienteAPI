using static CRUD_PacienteAPI.Models.Enums.Enum;

namespace CRUD_PacienteAPI.Models.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }

        public string DateBirth { get; set; }

        public string TaxNumber { get; set; }

        public SexualGender SexualGender { get; set; }

        public Address? Address { get; set; }

        public PatientStatus Status { get; set; }
    }
}