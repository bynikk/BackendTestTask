using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Providers;

public interface ISecurityExceptionLogProvider
{
    public IQueryable<SecurityExceptionLog> Get();
}
