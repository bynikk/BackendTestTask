using BackendTestTask.API.Infrastructure.Configurations;
using BackendTestTask.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;

services.AddControllers()
    .Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddInfrastructureServices()
    .AddBusinessLogicServices()
    .AddPostgresContext(options =>
    {
        var connectionString = configuration.GetConnectionString("TestTaskDbContext");
        options.UseNpgsql(connectionString, options => options.EnableRetryOnFailure(3));
    })
    .AddProviders()
    .AddRepositories();
;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
