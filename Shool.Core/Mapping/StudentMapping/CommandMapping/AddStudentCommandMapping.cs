using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                    .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DepartId))
                    .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
                    .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr));
        }
    }
}
