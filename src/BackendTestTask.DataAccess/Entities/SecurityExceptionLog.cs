namespace BackendTestTask.DataAccess.Entities;

public class SecurityExceptionLog
{
    public Guid Id { get; set; }

    public string ExceptionName { get; set; }

    public Guid CorrelationId { get; set; }

    public Guid DataId { get; set; }
    public virtual SecurityExceptionLogData? Data { get; set; }

    public DateTime CreatedAtUtc { get; set; }
}
