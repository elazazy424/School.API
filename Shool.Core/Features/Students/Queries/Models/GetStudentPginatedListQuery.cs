using MediatR;
using School.Core.Features.Students.Queries.ResultsDto;
using School.Core.Wrappers;
using School.Data.Helper;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentPginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
