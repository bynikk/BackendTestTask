using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Providers;
public class SecurityExceptionLogProvider : ISecurityExceptionLogProvider
{
    private readonly DbSet<SecurityExceptionLog> _dbSet;

    public SecurityExceptionLogProvider(DbSet<SecurityExceptionLog> dbSet)
    {
        _dbSet = dbSet;
    }

    public IQueryable<SecurityExceptionLog> Get()
    {
        var query = _dbSet.AsQueryable();

        return query;
    }
}
