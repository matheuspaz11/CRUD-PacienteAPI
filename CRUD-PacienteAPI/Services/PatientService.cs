using CRUD_PacienteAPI.Helpers.Validators;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;
using CRUD_PacienteAPI.Repository;
using static CRUD_PacienteAPI.Models.Enums.Enum;

namespace CRUD_PacienteAPI.Services
{
    public class PatientService
    {   
        public async Task ValidatePatient(PatientDTO patient, PatientRepository repository)
        {
            patient.TaxNumber = patient.TaxNumber.Replace(".", "").Replace("-", "");

            Patient patientExists = await repository.GetPatientByTaxNumber(patient.TaxNumber);

            if (patientExists != null)
                throw new Exception("TaxNumber já cadastrado na base de dados");
            else
                ValidateTaxNumber(patient.TaxNumber);

            ValidateSexualGender(patient.SexualGender);

            ValidateStatus(patient.Status);
        }

        public void ValidateActivePatient(Patient patient)
        {
            PatientExists(patient);

            if (patient.Status == PatientStatus.Inactive)
                throw new Exception("Paciente já se encontra como inativado");
        }

        public async Task ValidateUpdatePatient(UpdatePatientDTO updatePatientDTO, PatientRepository repository)
        {
            if (updatePatientDTO.TaxNumber != null)
            {
                updatePatientDTO.TaxNumber = updatePatientDTO.TaxNumber.Replace(".", "").Replace("-", "");

                Patient patientExists = await repository.GetPatientByTaxNumber(updatePatientDTO.TaxNumber);

                if (patientExists != null)
                    throw new Exception("TaxNumber já cadastrado na base de dados");
                else
                    ValidateTaxNumber(updatePatientDTO.TaxNumber);
            }

            if (updatePatientDTO.SexualGender != null)
                ValidateSexualGender(updatePatientDTO.SexualGender);

            if (updatePatientDTO.Status != null)
                ValidateStatus(updatePatientDTO.Status);
        }

        public void PatientExists(Patient patient)
        {
            if (patient == null)
                throw new Exception("Paciente não encontrado na base de dados");
        }

        public void ValidateTaxNumber(string taxNumber)
        {
            bool validateCpf = ValidateCPF.IsValidCPF(taxNumber);

            if (!validateCpf)
                throw new Exception("TaxNumber inválido, forneça um TaxNumber válido");
        }

        public void ValidateSexualGender(int? patientSexualGender)
        {
            bool validateSexualGender = Enum.IsDefined(typeof(SexualGender), patientSexualGender);

            if (!validateSexualGender)
                throw new Exception("SexualGender inválido, forneça um SexualGender válido");
        }

        public void ValidateStatus(int? patientStatus)
        {
            bool validateStatus = Enum.IsDefined(typeof(PatientStatus), patientStatus);

            if (!validateStatus)
                throw new Exception("Status inválido, forneça um Status válido");
        }
    }
}