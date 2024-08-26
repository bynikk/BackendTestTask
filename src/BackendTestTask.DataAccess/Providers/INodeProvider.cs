using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Providers;

public interface INodeProvider
{
    IQueryable<Node> Get(Guid nodeId);

    IQueryable<Node> GetRange();
}
