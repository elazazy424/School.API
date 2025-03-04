using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.ApplicationUser.Queries.Models;
using School.Core.Features.ApplicationUser.Queries.Results;
using School.Core.SharedResources;
using School.Core.Wrappers;
using School.Data.Entities.Identity;

namespace School.Core.Features.ApplicationUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationResponse>>,
        IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Resources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        #endregion
        #region ctor
        public UserQueryHandler(IMapper mapper, IStringLocalizer<Resources> stringLocalizer, UserManager<User> userManager) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
        }
        #endregion
        public async Task<PaginatedResult<GetUserPaginationResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();

            var paginatedList = await _mapper.ProjectTo<GetUserPaginationResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }
    }
}
