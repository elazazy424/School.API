using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.ApplicationUser.Commands.Models;

namespace School.Core.Features.ApplicationUser.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer _stringLocalizer;
        #endregion
        #region constructor
        public AddUserValidator(IStringLocalizer stringLocalizer)
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

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.ConfirmPassword)
              .Equal(x => x.Password)
              .WithMessage("Password and Confirm Password must be same")
              .NotEmpty()
              .NotNull();
        }
        #endregion
    }
}
