using CRUD_PacienteAPI.Context;
using CRUD_PacienteAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_PacienteAPI.Repository
{
    public class PatientRepository : BaseRepository
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
    }
}
