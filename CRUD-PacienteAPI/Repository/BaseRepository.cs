using CRUD_PacienteAPI.Context;
using CRUD_PacienteAPI.Repository.Interfaces;

namespace CRUD_PacienteAPI.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly PatientContext _context;

        public BaseRepository(PatientContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
