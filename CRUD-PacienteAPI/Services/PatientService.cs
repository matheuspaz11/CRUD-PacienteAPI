using CRUD_PacienteAPI.Helpers.Validators;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;
using static CRUD_PacienteAPI.Models.Enums.Enum;

namespace CRUD_PacienteAPI.Services
{
    public class PatientService
    {   
        public void ValidatePatient(PatientDTO patientDTO)
        {
            patientDTO.TaxNumber = patientDTO.TaxNumber.Replace(".", "").Replace("-", "");

            bool validateCpf = ValidateCPF.IsValidCPF(patientDTO.TaxNumber);

            if(!validateCpf)
                throw new Exception("TaxNumber inválido, forneça um TaxNumber válido");

            bool validateSexualGender = Enum.IsDefined(typeof(SexualGender), patientDTO.SexualGender);

            if(!validateSexualGender)
                throw new Exception("SexualGender inválido, forneça um SexualGender válido");

            bool validateStatus = Enum.IsDefined(typeof(PatientStatus), patientDTO.Status);

            if (!validateStatus)
                throw new Exception("Status inválido, forneça um Status válido");
        }

        public void ValidateActivePatient(Patient patient)
        {
            if (patient == null)
                throw new Exception("Paciente não encontrado na base de dados");

            if (patient.Status == PatientStatus.Inactive)
                throw new Exception("Paciente já se encontra como inativado");
        }
    }
}