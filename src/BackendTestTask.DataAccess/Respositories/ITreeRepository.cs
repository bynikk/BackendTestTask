using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Respositories;

public interface ITreeRepository
{
    Task Add(Tree tree, CancellationToken cancellationToken);
}
