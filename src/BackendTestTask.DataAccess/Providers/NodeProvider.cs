using BackendTestTask.DataAccess.Data;
using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Providers;

public class NodeProvider : INodeProvider
{
    private readonly TestTaskDbContext _context;

    public NodeProvider(TestTaskDbContext context)
    {
        _context = context;
    }

    public IQueryable<Node> Get(Guid nodeId)
    {
        return _context.Nodes.Where(node => node.Id == nodeId);
    }

    public IQueryable<Node> GetRange()
    {
        var query = _context.Nodes.AsQueryable();

        return query;
    }
}
