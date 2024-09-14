using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestTask.DataAccess.Providers;

public class NodeProvider : INodeProvider
{
    private readonly DbSet<Node> _dbSet;

    public NodeProvider(DbSet<Node> dbSet)
    {
        _dbSet = dbSet;
    }

    public IQueryable<Node> Get(Guid nodeId)
    {
        return _dbSet.Where(node => node.Id == nodeId);
    }

    public IQueryable<Node> GetRange()
    {
        var query = _dbSet.AsQueryable();

        return query;
    }
}
