using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Results;
using School.Core.Features.Students.Queries.ResultsDto;
using School.Core.SharedResources;
using School.Core.Wrappers;
using School.Data.Entities;
using School.Service.Interfaces;
using Shool.Core.Features.Students.Queries.Models;
using System.Linq.Expressions;

namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                      IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                      IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
                                      IRequestHandler<GetStudentPginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        //it will execute the service
        #region depedency of the service
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Resources> _stringLocalizer;


        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<Resources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region GetStudentListResponse
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentList = await _studentService.GetStudentsListAsync();
            var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList); //<destination> ==> (source) ha5od mn el source w 27ot fee el destination
            var result = Success(StudentListMapper);
            result.Meta = new { Count = StudentListMapper.Count() };
            return result;
        }
        #endregion
        #region GetStudentResponse by id
        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var result = _mapper.Map<GetStudentResponse>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPginatedListQuery request, CancellationToken cancellationToken)
        {
            //bdila ll mapping
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.NameAr, e.NameEn));
            // var querable = _studentService.GetStudentsQuerable();
            var filterQuery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginatedList.Meta = new { count = paginatedList.Data.Count() };
            return paginatedList;
        }

        #endregion
    }
}
