using CRUD_PacienteAPI.Helpers.Validators;
using CRUD_PacienteAPI.Models.DTOs;

namespace CRUD_PacienteAPI.Services
{
    public class PatientService
    {   
        public void ValidatePatient(PatientDTO patientDTO)
        {
            bool validateCpf = ValidateCPF.IsValidCPF(patientDTO.TaxNumber);

            if(!validateCpf)
            {
                throw new Exception("TaxNumber inválido");
            }
        }
    }
}
