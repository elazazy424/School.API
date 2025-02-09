using School.Core.Features.Students.Queries.Results;
using School.Data.Entities;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.NameAr, src.NameEn)))
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
