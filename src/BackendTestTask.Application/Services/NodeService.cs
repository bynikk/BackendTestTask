using BackendTestTask.Abstractions.Services;

namespace BackendTestTask.Application.Services;
public class NodeService : INodeService
{
    public Task AddNode(Guid treeId, string name, Guid? parentNodeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<NodeDto> GetById(Guid nodeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<NodeDto>> GetRangeByTreeId(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Guid nodeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
