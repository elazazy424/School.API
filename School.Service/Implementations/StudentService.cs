using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Data.Helper;
using School.Infastructure.Interfaces;
using School.Service.Interfaces;

//benefits of services that we put all logic here
namespace School.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region inject repos
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region get student list
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        #endregion
        #region get student by id
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                                  .Include(x => x.Department)
                                                  .Where(x => x.Id == id)
                                                  .FirstOrDefaultAsync();
            return student;
        }
        #endregion
        #region add student 
        public async Task<string> AddStudentAsync(Student student)
        {


            await _studentRepository.AddAsync(student);
            return "Added Succesfully";
        }
        #endregion
        #region is name exist
        public async Task<bool> IsNameExist(string name)
        {
            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(name)).FirstOrDefault();
            if (student == null)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region IsNameExistExcludeSelf
        public async Task<bool> IsNameExistExcludeSelf(string name, int Id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(name) & x.Id.Equals(Id)).FirstOrDefaultAsync();
            if (student == null)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region edit
        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        #endregion
        #region delete
        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Deleted";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return ex.Message;
            }
        }
        #endregion
        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.NameAr.Contains(search) || x.Address.Contains(search));
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudtId:
                    querable = querable.OrderBy(x => x.Id);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.NameEn);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(x => x.Department.NameAr);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                default:
                    querable = querable.OrderBy(x => x.Id);
                    break;
            }
            return querable;
        }

        public IQueryable<Student> GetStudentsDepartmentIDQuerable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.Id.Equals(DID)).AsQueryable();
        }
    }
}
