using BackendTestTask.Abstractions.Providers;
using BackendTestTask.Core.Entities;
using BackendTestTask.Infrastructure.Data;

namespace BackendTestTask.Infrastructure.Providers;

public class TreeProvider : ITreeProvider
{
    private readonly TestTaskDbContext _context;

    public TreeProvider(TestTaskDbContext context)
    {
        _context = context;
    }

    public IQueryable<Tree> Get(Guid treeId)
    {
        return _context.Trees.Where(tree => tree.Id == treeId);
    }

    public IQueryable<Tree> GetRange()
    {
        return _context.Trees.AsQueryable();
    }
}
