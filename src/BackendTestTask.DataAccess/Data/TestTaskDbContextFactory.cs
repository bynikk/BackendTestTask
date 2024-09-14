using BackendTestTask.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeneralService.DataAccess.DbContext;

/// <summary>
/// Context factory
/// </summary>
public class TestTaskDbContextFactory : IDesignTimeDbContextFactory<TestTaskDbContext>
{
    /// <summary>
    /// Creates a new instance of a derived context.
    /// </summary>
    /// <param name="args">Arguments provided by the design-time service.</param>
    public TestTaskDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TestTaskDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestTaskDbContext;User Id=postgres;Password=postgres");

        return new TestTaskDbContext(optionsBuilder.Options);
    }
}
