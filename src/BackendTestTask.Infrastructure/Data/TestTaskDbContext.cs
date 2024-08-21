using BackendTestTask.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.Infrastructure.Data;

public class TestTaskDbContext : DbContext
{
    public TestTaskDbContext() { }

    public DbSet<Node> Nodes { get; set; }

    public DbSet<Tree> Trees { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(TestTaskDbContext).Assembly);

        base.OnModelCreating(builder);
    }
}
