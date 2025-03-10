using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.ApplicationUser.Commands.Models;

namespace School.Core.Features.ApplicationUser.Commands.Validators
{
    internal class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer _stringLocalizer;
        #endregion
        #region constructor
        public EditUserValidator(IStringLocalizer stringLocalizer)
        {
            ApplyValidationRules();
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Functions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("FullName is required")
                .MaximumLength(100).WithMessage("Max Length is 100");

            RuleFor(x => x.UserName)
              .NotEmpty()
              .WithMessage("UserName is required")
              .MaximumLength(100).WithMessage("Max Length is 100");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is not valid")
                .MaximumLength(100).WithMessage("Max Length is 100");

            RuleFor(x => x.Address)
                .MaximumLength(100).WithMessage("Max Length is 100");
        }
        #endregion
    }
}
