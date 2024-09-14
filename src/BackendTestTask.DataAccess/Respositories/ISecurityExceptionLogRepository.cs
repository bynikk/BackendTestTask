using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Respositories;
public interface ISecurityExceptionLogRepository
{
    public Task Add(SecurityExceptionLog entity, CancellationToken cancellationToken = default);
}
