using CRUD_PacienteAPI.Context;
using CRUD_PacienteAPI.Models.DTOs;
using CRUD_PacienteAPI.Models.Entities;
using CRUD_PacienteAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_PacienteAPI.Repository
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        private readonly PatientContext _context;

        public PatientRepository(PatientContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientByTaxNumber(string taxNumber)
        {
            return await _context.Patients.Where(x => x.TaxNumber == taxNumber).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PatientDTO>> GetPatients(string? name)
        {
            List<Patient> patients;

            if (string.IsNullOrEmpty(name))
                patients = await _context.Patients.Include(p => p.Address).ToListAsync();
            else
                patients = await _context.Patients.Include(p => p.Address).Where(p => p.Name.Contains(name)).ToListAsync();

            var patientDTOs = patients.Select(p => new PatientDTO
            {
                Name = p.Name,
                DateBirth = p.DateBirth,
                TaxNumber = p.TaxNumber,
                SexualGender = (int)p.SexualGender,
                Address = p.Address == null ? null : new AddressDTO
                {
                    Street = p.Address?.Street,
                    Neighborhood = p.Address?.Neighborhood,
                    HouseNumber = (int)(p.Address?.HouseNumber),
                    City = p.Address?.City,
                    State = p.Address?.State
                },
                Status = (int)p.Status
            }).ToList();

            return patientDTOs;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}