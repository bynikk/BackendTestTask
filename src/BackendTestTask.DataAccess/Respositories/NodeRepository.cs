using BackendTestTask.DataAccess.Data;
using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Respositories;

public class NodeRepository : INodeRepository
{
    private readonly TestTaskDbContext _context;

    public NodeRepository(TestTaskDbContext context)
    {
        _context = context;
    }

    public Task Add(Node node, CancellationToken cancellationToken)
    {
        return _context.Nodes.AddAsync(node, cancellationToken).AsTask();
    }

    public Task Remove(Node node, CancellationToken cancellationToken)
    {
        return Task.FromResult(_context.Nodes.Remove(node));
    }
}
