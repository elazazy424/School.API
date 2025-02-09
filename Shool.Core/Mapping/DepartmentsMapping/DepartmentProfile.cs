using AutoMapper;

namespace School.Core.Mapping.DepartmentsMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();
        }
    }
}
