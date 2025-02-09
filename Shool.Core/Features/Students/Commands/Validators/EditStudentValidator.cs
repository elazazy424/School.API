using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Service.Interfaces;

namespace School.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region  fields
        private readonly IStudentService _studentService;

        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion

        #region constructors
        public EditStudentValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr).NotEmpty()
                                .WithMessage("Name must not empty")
                                .NotNull().WithMessage("Name must not be null")
                                .MaximumLength(100).WithMessage("Name Has maxiumum 10 chars");

            RuleFor(x => x.Address).NotEmpty()
                                   .WithMessage("{PropertyName} must not empty")
                                   .NotNull().WithMessage("{PropertyName} must not be null")
                                   .MaximumLength(10).WithMessage("{PropertyName} Has maxiumum 10 chars");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr).MustAsync(async (model, Key, CancellationToken) => !await _studentService
                                .IsNameExistExcludeSelf(Key, model.Id))
                                .WithMessage("Name Is Exist");
        }
        #endregion
    }
}
