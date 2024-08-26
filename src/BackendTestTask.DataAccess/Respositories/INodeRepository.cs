using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Respositories;

public interface INodeRepository
{
    Task Add(Node node, CancellationToken cancellationToken);

    Task Remove(Node node, CancellationToken cancellationToken);
}
