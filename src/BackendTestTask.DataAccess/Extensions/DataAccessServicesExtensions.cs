using BackendTestTask.DataAccess.Data;
using BackendTestTask.DataAccess.Entities;
using BackendTestTask.DataAccess.Providers;
using BackendTestTask.DataAccess.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackendTestTask.DataAccess.Extensions;

/// <summary>
/// Data layer extenions for <seealso cref="IServiceCollection"/>
/// </summary>
public static class DataAccessServicesExtensions
{
    /// <summary>
    /// Adds the postgres context.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="options">The options.</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddPostgresContext(this IServiceCollection services,
        Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContextPool<TestTaskDbContext>(options);
        services.AddScoped<IDataContext, DataContext>();

        services.AddScopedDbSet<Node>()
                .AddScopedDbSet<Tree>()
                .AddScopedDbSet<SecurityExceptionLog>()
                .AddScopedDbSet<SecurityExceptionLogData>();

        return services;
    }

    /// <summary>
    /// Adds db repositories to DI container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<INodeRepository, NodeRepository>()
                .AddScoped<ITreeRepository, TreeRepository>()
                .AddScoped<ISecurityExceptionLogRepository, SecurityExceptionLogRepository>();

        return services;
    }

    /// <summary>
    /// Adds db providers to DI container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.AddScoped<INodeProvider, NodeProvider>()
                .AddScoped<ITreeProvider, TreeProvider>()
                .AddScoped<ISecurityExceptionLogProvider, SecurityExceptionLogProvider>();

        return services;
    }

    /// <summary>
    /// Adds the scoped database set.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection</returns>
    private static IServiceCollection AddScopedDbSet<TEntity>(this IServiceCollection services)
        where TEntity : class
    {
        services.AddScoped(serviceProvider =>
            serviceProvider.GetRequiredService<TestTaskDbContext>().Set<TEntity>());

        return services;
    }
}
