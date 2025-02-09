using School.Data.Entities;

namespace School.Infastructure.Interfaces
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        public Task<List<Student>> GetStudentsListAsync();
    }
}
