using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.Departments.Queries.Models;
using School.Core.Features.Departments.Queries.Results;
using School.Core.SharedResources;
using School.Core.Wrappers;
using School.Data.Entities;
using School.Service.Interfaces;
using System.Linq.Expressions;

namespace School.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
                            IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        public IStringLocalizer<Resources> _stringLocalizer { get; }

        #endregion
        #region Constructors
        public DepartmentQueryHandler(IStringLocalizer<Resources> stringLocalizer, IDepartmentService departmentService, IMapper mapper, IStudentService studentService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _departmentService = departmentService;
            _mapper = mapper;
            _studentService = studentService;
        }

        #endregion
        #region Functions
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            //service get by id include student, subject , instructor
            var response = await _departmentService.GetDepartmentById(request.Id);
            //check is not exist
            if (response == null)
            {
                return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            //mapping
            var mapper = _mapper.Map<GetDepartmentByIdResponse>(response);

            //pagination
            Expression<Func<Student, StudentResponse>> studentSelector = x => new StudentResponse(x.Id, x.Localize(x.NameAr, x.NameEn));

            var studentQuerable = _studentService.GetStudentsDepartmentIDQuerable(request.Id);
            var paginatedResult = await studentQuerable.Select(studentSelector).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = paginatedResult;

            //return
            return Success(mapper);
        }
        #endregion

    }
}
