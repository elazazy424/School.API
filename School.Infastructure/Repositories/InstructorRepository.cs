using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infastructure.Data;
using School.Infastructure.Interfaces;

namespace School.Infastructure.Repositories
{
    internal class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        #region Fields
        private DbSet<Instructor> _instructors;
        #endregion
        #region Constructor
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
            _instructors = context.Set<Instructor>();
        }
        #endregion
        #region Functions

        #endregion
    }
}
