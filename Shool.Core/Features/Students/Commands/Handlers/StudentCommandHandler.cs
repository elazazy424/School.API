using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.Interfaces;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                      IRequestHandler<AddStudentCommand, Response<string>>,
                                      IRequestHandler<EditStudentCommand, Response<string>>,
                                      IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region dependency injection
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer _stringLocalizer;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<School.Core.SharedResources.Resources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddStudentAsync(studentMapper);
            //if (result == "Student already exists")
            //{
            //    return UnprocessableEntity<string>("Name Is Already Exists");
            //}
            if (result == "Added Succesfully")
            {
                return Created("Added Succefully");
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check id the id is exist or not
            var student = await _studentService.GetByIdAsync(request.Id);
            //return not found
            if (student == null)
            {
                return NotFound<string>("Student is not found");
            }
            //mapping between req and student
            var studentMapper = _mapper.Map(request, student);
            //call service that make edit
            var result = await _studentService.EditAsync(studentMapper);
            //return response
            if (result == "Success")
            {
                return Success("Edit Succefully " + studentMapper.Id);
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // check id the id is exist or not
            var student = await _studentService.GetByIdAsync(request.Id);
            //return not found
            if (student == null)
            {
                return NotFound<string>("Student is not found");
            }
            //call service that make delete
            var result = await _studentService.DeleteAsync(student);
            //return response
            if (result == "Deleted")
            {
                return Deleted<string>($"Deleted Succefully {request.Id}");
            }
            else
            {
                return BadRequest<string>();
            }
        }
    }
}
