using School.Core.Features.ApplicationUser.Queries.Results;
using School.Data.Entities.Identity;

namespace School.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserPaginationMapping()
        {
            CreateMap<User, GetUserPaginationResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
        }
    }
}
