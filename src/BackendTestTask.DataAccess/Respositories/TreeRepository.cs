using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Respositories;

public class TreeRepository : ITreeRepository
{
    private readonly DbSet<Tree> _trees;

    public TreeRepository(DbSet<Tree> trees)
    {
        _trees = trees;
    }

    public Task Add(Tree tree, CancellationToken cancellationToken)
    {
        return _trees.AddAsync(tree, cancellationToken).AsTask();
    }
}
