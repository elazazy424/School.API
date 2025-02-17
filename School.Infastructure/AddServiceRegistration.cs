using Microsoft.Extensions.DependencyInjection;
using School.Data.Entities.Identity;
using School.Infastructure.Data;

namespace School.Infastructure
{
    public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(option =>
        {
            //password settings
            option.Password.RequireDigit = true;
            option.Password.RequireLowercase = true;
            option.Password.RequireUppercase = true;
            option.Password.RequireNonAlphanumeric = true;
            option.Password.RequiredLength = 6;
            option.Password.RequiredUniqueChars = 6;

            //lockout settings
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            option.Lockout.MaxFailedAccessAttempts = 5;
            option.Lockout.AllowedForNewUsers = true;

            //user settings
            option.User.RequireUniqueEmail = false;
            option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";


        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

        return services;
    }
}
