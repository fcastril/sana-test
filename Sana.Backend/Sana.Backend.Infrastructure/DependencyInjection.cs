using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories;
using Sana.Backend.Infrastructure.SQLServer;
using Configurations = Sana.Backend.Infrastructure.SQLServer.Configurations;

namespace Sana.Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<MainContext>(options => options.UseSqlServer(configuration[$"{nameof(Configurations.SQLServer)}:{nameof(Configurations.SQLServer.ConnectionString)}"]));
            services.AddSingleton<Configurations.IConfigurateSQLServer>(sp => sp.GetRequiredService<IOptions<Configurations.SQLServer>>().Value);

            services.AddScoped<IMainContext, MainContext>();

            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IOrderDetailRepository), typeof(OrderDetailRepository));
            return services;
        }
    }
}
