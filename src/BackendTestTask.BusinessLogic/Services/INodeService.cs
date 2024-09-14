using BackendTestTask.BusinessLogic.DTOs;

namespace BackendTestTask.BusinessLogic.Services;

public interface INodeService
{
    Task<Guid> Add(Guid treeId, string name, Guid? parentNodeId, CancellationToken cancellationToken);

    Task Remove(Guid nodeId, CancellationToken cancellationToken);

    Task<NodeDto?> GetById(Guid nodeId, CancellationToken cancellationToken);

    Task<List<NodeDto>> GetRangeByTreeId(Guid treeId, CancellationToken cancellationToken);
}
