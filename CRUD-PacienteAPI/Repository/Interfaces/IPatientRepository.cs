using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;

namespace CRUD_PacienteAPI.Repository.Interfaces
{
    public interface IPatientRepository : IBaseRepository
    {
        Task<Patient> GetPatientByTaxNumber(string taxNumber);

        Task<IEnumerable<PatientDTO>> GetPatients(string? name);
    }
}
