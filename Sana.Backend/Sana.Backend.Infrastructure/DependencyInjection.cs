using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sana.Backend.Domain.Port.Base;
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

            //services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            //services.AddScoped(typeof(IRolRepository), typeof(RolRepository));

            return services;
        }
    }
}
