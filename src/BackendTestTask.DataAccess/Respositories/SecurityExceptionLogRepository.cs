using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Respositories;

public class SecurityExceptionLogRepository : ISecurityExceptionLogRepository
{
    private readonly DbSet<SecurityExceptionLog> _dbSet;

    public SecurityExceptionLogRepository(DbSet<SecurityExceptionLog> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task Add(SecurityExceptionLog entity, CancellationToken cancellationToken = default)
    {
        return _dbSet.AddAsync(entity, cancellationToken).AsTask();
    }
}
