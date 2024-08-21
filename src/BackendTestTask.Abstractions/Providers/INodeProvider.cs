using BackendTestTask.Core.Entities;

namespace BackendTestTask.Abstractions.Providers;

public interface INodeProvider
{
    IQueryable<Node> Get(Guid nodeId);
}
