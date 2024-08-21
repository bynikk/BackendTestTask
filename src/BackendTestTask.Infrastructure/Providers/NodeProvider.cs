using BackendTestTask.Abstractions.Providers;
using BackendTestTask.Core.Entities;
using BackendTestTask.Infrastructure.Data;

namespace BackendTestTask.Infrastructure.Providers;

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
}
