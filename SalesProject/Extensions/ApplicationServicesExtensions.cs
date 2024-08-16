
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SalesProject.Domain.IService;

namespace SalesProject.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration configuration)
        {
           
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /*
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailSettings>();
            services.AddSingleton(emailConfig);*/
         
            return services;
        }
    }
}
