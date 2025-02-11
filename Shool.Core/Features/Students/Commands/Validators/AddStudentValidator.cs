using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.Students.Commands.Models;
using School.Core.SharedResources;
using School.Service.Interfaces;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region  fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<Resources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;


        #endregion

        #region constructors
        public AddStudentValidator(IStudentService studentService, IStringLocalizer<Resources> stringLocalizer, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
            _departmentService = departmentService;
        }
        #endregion

        #region actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                                .NotNull().WithMessage("Name must not be null")
                                .MaximumLength(10).WithMessage("Name Has maxiumum 10 chars");

            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} must not empty")
                                .NotNull().WithMessage("{PropertyName} must not be null")
                                .MaximumLength(10).WithMessage("{PropertyName} Has maxiumum 10 chars");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr).MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DepartId)
                .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.DepartmentIdIsNotExist]);
        }
        #endregion

    }
}
