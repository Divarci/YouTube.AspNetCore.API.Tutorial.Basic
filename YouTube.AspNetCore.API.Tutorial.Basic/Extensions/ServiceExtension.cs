using Microsoft.EntityFrameworkCore;
using YouTube.AspNetCore.API.Tutorial.Basic.Context;
using YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories;
using YouTube.AspNetCore.API.Tutorial.Basic.MapperApp;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceItemServices;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("SqlConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IInvoiceItemService, InvoiceItemService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IMapper, Mapper>();

            return services;
        }
    }
}
