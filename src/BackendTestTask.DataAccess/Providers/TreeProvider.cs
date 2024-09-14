using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Providers;

public class TreeProvider : ITreeProvider
{
    private readonly DbSet<Tree> _dbSet;

    public TreeProvider(DbSet<Tree> dbSet)
    {
        _dbSet = dbSet;
    }

    public IQueryable<Tree> Get(Guid treeId)
    {
        return _dbSet
            .Where(tree => tree.Id == treeId)
            .Include(tree => tree.Nodes);
    }

    public IQueryable<Tree> GetRange()
    {
        return _dbSet.AsQueryable();
    }
}
