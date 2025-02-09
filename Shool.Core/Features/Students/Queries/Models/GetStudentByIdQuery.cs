using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.ResultsDto;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
                Id= id;
        }
    }
}
