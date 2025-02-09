using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infastructure.Interfaces;
using School.Service.Interfaces;

namespace School.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentRepository.GetTableNoTracking().Where(x => x.Id.Equals(id))
                                                       .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                                                       .Include(x => x.instructors)
                                                       .Include(x => x.instructor).FirstOrDefaultAsync();
        }
    }
}
