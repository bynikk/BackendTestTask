using BackendTestTask.BusinessLogic.DTOs;

namespace BackendTestTask.BusinessLogic.Services;

public interface ITreeService
{
    Task<Guid> Add(string name, CancellationToken cancellationToken);

    Task<List<TreeDto>> GetRange(CancellationToken cancellationToken);

    Task<TreeDto?> Get(Guid treeId, int depth, CancellationToken cancellationToken);
}
