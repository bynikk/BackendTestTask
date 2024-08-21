using BackendTestTask.Abstractions.Respositories;
using BackendTestTask.Core.Entities;
using BackendTestTask.Infrastructure.Data;

namespace BackendTestTask.Infrastructure.Respositories;

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
