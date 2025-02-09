using MediatR;

namespace School.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Bases.Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartId { get; set; }
    }
}
