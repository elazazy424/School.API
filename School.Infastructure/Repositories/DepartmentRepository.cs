using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infastructure.Data;
using School.Infastructure.Interfaces;

namespace School.Infastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        #region Fields and properties
        private DbSet<Department> departments;
        #endregion
        #region Constructor
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            departments = context.Set<Department>();
        }
        #endregion
        #region Handle Functions

        #endregion

    }
}
