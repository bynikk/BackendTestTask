using BackendTestTask.API.Infrastructure.Mappings;
using BackendTestTask.Application.Services;
using BackendTestTask.BusinessLogic.Mappings;
using BackendTestTask.BusinessLogic.Services;

namespace BackendTestTask.API.Infrastructure.Configurations;

/// <summary>
/// App configuration
/// </summary>
public static partial class AppConfigurations
{
    /// <summary>Adds the infrastructure services to service collection</summary>
    /// <param name="services">The service collection.</param>
    /// <returns> <seealso cref="IServiceCollection"/> </returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddAutoMapper(typeof(DtoProfile).Assembly)
            .AddAutoMapper(typeof(ApiProfile).Assembly);

        return services;
    }

    /// <summary>Adds the business logic services to service collection</summary>
    /// <param name="services">The service collection.</param>
    /// <returns> <seealso cref="IServiceCollection"/>  </returns>
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services
            .AddScoped<INodeService, NodeService>()
            .AddScoped<ITreeService, TreeService>()
            .AddScoped<ISecurityExceptionLogService, SecurityExceptionLogService>();

        return services;
    }
}
