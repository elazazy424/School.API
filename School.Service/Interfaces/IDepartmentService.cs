using School.Data.Entities;

namespace School.Service.Interfaces
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
    }
}
