using BackendTestTask.Core.Entities;

namespace BackendTestTask.Abstractions.Providers;

public interface ITreeProvider
{
    IQueryable<Tree> Get(Guid treeId);

    IQueryable<Tree> GetRange();
}
