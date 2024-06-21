using Microsoft.EntityFrameworkCore;
using YouTube.AspNetCore.API.Tutorial.Basic.Context;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("SqlConnection")));
            return services;
        }
    }
}
