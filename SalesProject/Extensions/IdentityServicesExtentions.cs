
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using SalesProject.Domain.DomaimModels.Users;
using System.Text;

namespace SalesProject.Extensions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<SalesDbContext>().AddDefaultTokenProviders();
        
            return services;
        }
    }
}
