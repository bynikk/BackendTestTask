namespace BackendTestTask.DataAccess.Data;

public class DataContext : IDataContext
{
    private readonly TestTaskDbContext _testTaskDbContext;

    public DataContext(TestTaskDbContext testTaskDbContext)
    {
        _testTaskDbContext = testTaskDbContext;
    }
    public Task CommitChangesAsync(CancellationToken cancellationToken)
    {
        return _testTaskDbContext.SaveChangesAsync(cancellationToken);
    }
}
