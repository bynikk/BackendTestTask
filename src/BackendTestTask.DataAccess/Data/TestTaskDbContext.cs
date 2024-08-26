using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Data;

public class TestTaskDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }

    public DbSet<Tree> Trees { get; set; }

    public TestTaskDbContext() { }

    public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(TestTaskDbContext).Assembly);

        base.OnModelCreating(builder);
    }
}
