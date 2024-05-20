using HotChocolate;
using Sana.Backend.Infrastructure.GraphQL.Queries;

namespace Sana.Backend.GraphQL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                   .AddQueryType<Query>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }

    }
}
