namespace BackendTestTask.API.Infrastructure.Configurations;

public static partial class AppConfigurations
{
    /// <summary>
    /// Adds the application settings.
    /// </summary>
    /// <param name="appBuilder">The application builder.</param>
    /// <returns>WebApplicationBuilder</returns>
    public static WebApplicationBuilder AddAppSettings(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Host.ConfigureAppConfiguration(config =>
        {
            var prefix = "BackendTestTask_";
            config.AddEnvironmentVariables(prefix);
            config.Build();
        });

        return appBuilder;
    }
}
