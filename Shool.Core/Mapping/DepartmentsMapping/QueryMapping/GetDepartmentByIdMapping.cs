using School.Core.Features.Departments.Queries.Results;
using School.Data.Entities;

namespace School.Core.Mapping.DepartmentsMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.instructor.Localize(src.NameAr, src.NameEn)))
                    .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                    //.ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                    .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.instructors));

            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.Localize(src.Subjects.NameAr, src.Subjects.NameEn)));

            //CreateMap<Student, StudentResponse>()
            //   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<Instructor, InstructorResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.INameAr, src.INameEn)));
        }
    }
}
