using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Respositories;

public class NodeRepository : INodeRepository
{
    private readonly DbSet<Node> _dbSet;

    public NodeRepository(DbSet<Node> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task Add(Node node, CancellationToken cancellationToken)
    {
        return _dbSet.AddAsync(node, cancellationToken).AsTask();
    }

    public Task Remove(Node node, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dbSet.Remove(node));
    }
}
