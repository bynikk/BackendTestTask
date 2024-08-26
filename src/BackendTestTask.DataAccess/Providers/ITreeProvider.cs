using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Providers;

public interface ITreeProvider
{
    IQueryable<Tree> Get(Guid treeId);

    IQueryable<Tree> GetRange();
}
