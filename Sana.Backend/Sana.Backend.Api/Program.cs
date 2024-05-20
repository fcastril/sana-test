using Sana.Backend.Infrastructure;
using Sana.Backend.Infrastructure.GraphQL.Queries;



var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});
app.UseCors("MyPolicyCors");

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddDependencyInjectionsInfrastructure(builder.Configuration);
    services.AddGraphQLServer()
        .AddQueryType<Query>();

    services.AddCors(options =>
    {
        options.AddPolicy(name: "MyPolicyCors", builder =>
        {
            builder.AllowAnyOrigin();

        });

    });
}

