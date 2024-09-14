using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Respositories;

public class TreeRepository : ITreeRepository
{
    private readonly DbSet<Tree> _dbSet;

    public TreeRepository(DbSet<Tree> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task Add(Tree tree, CancellationToken cancellationToken)
    {
        return _dbSet.AddAsync(tree, cancellationToken).AsTask();
    }
}
