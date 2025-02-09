using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infastructure.Data;
using School.Infastructure.Interfaces;

namespace School.Infastructure.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        #region fields
        private DbSet<Subject> subjects;
        #endregion
        #region constructor
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            subjects = context.Set<Subject>();
        }
        #endregion
        #region functions

        #endregion
    }
}
