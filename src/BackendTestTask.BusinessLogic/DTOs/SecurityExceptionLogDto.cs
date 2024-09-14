namespace BackendTestTask.BusinessLogic.DTOs;

public class SecurityExceptionLogDto
{
    public Guid Id { get; set; }

    public string ExceptionName { get; set; }

    public Guid CorrelationId { get; set; }

    public virtual SecurityExceptionLogDto? Data { get; set; }

    public DateTime CreatedAtUtc { get; set; }
}
