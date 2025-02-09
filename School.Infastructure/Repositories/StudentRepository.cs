using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infastructure.Data;
using School.Infastructure.Interfaces;

namespace School.Infastructure.Repositories
{
    public class StudentRepository :GenericRepository<Student>, IStudentRepository
    {
        #region Depedency injection
        private readonly DbSet<Student> _students;

        public StudentRepository(ApplicationDbContext context) : base(context) 
        {
            _students = context.Set<Student>();
        }

        
        #endregion

        #region GetStudentsListAsync
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _students.Include(x => x.Department).ToListAsync();
        }
        #endregion
    }
}
