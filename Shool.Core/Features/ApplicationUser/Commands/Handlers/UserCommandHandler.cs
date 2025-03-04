using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.ApplicationUser.Commands.Models;
using School.Core.SharedResources;
using School.Data.Entities.Identity;


namespace School.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly UserManager<User> _userManager;


        #endregion
        #region constructor
        public UserCommandHandler(IStringLocalizer<Resources> stringLocalizer,
            IMapper mapper,
            UserManager<User> userManager) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
        }
        #endregion
        #region Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //if email is already exist
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return BadRequest<string>(_stringLocalizer["EmailAlreadyExist"]);
            }
            //if username is exist
            user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return BadRequest<string>(_stringLocalizer["UserNameAlreadyExist"]);
            }
            //create user
            var IdentityUser = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(IdentityUser, request.Password);
            //if user created successfully
            if (result.Succeeded)
            {
                return Created("Created Successfully");
            }
            //if user creation failed
            return BadRequest<string>(result.Errors.FirstOrDefault().Description);



        }
        #endregion

    }
}
