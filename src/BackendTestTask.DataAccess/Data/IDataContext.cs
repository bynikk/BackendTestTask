namespace BackendTestTask.DataAccess.Data;

public interface IDataContext
{
    public Task CommitChangesAsync(CancellationToken cancellationToken);
}
