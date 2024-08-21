namespace BackendTestTask.Abstractions.Services;
public interface INodeService
{
    Task AddNode(Guid treeId, string name, Guid? parentNodeId, CancellationToken cancellationToken);

    Task Remove(Guid nodeId, CancellationToken cancellationToken);

    Task<NodeDto> GetById(Guid nodeId, CancellationToken cancellationToken);

    Task<List<NodeDto>> GetRangeByTreeId(CancellationToken cancellationToken);
}
