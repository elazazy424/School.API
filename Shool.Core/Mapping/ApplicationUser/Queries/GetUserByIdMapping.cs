using School.Core.Features.ApplicationUser.Queries.Results;
using School.Data.Entities.Identity;

namespace School.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();

        }
    }
}
