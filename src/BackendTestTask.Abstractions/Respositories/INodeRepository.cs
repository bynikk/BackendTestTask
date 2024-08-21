using BackendTestTask.Core.Entities;

namespace BackendTestTask.Abstractions.Respositories;

public interface INodeRepository
{
    Task Add(Node node, CancellationToken cancellationToken);

    Task Remove(Node node, CancellationToken cancellationToken);
}
