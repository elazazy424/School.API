using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                    .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DepartId))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
                    .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr));
        }
    }
}
