using BackendTestTask.BusinessLogic.DTOs;
using BackendTestTask.BusinessLogic.Models;

namespace BackendTestTask.BusinessLogic.Services;

public interface ISecurityExceptionLogService
{
    public Task<List<SecurityExceptionLogDto>> GetRange(CancellationToken cancellationToken = default);

    public Task<Guid> Add(SecurityExceptionLogCreateModel createModel, CancellationToken cancellationToken = default);
}
