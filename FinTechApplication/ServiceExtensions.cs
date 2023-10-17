using FinTechApplication.Infrastructure.Database;
using FinTechApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace FinTechApplication
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>(q => q.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}
