using School.Core.Features.Students.Queries.ResultsDto;
using School.Data.Entities;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentResponse>()
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.NameAr))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
