namespace BackendTestTask.BusinessLogic.Models;
public class SecurityExceptionLogCreateModel
{
    public string ExceptionName { get; set; }

    public string ExeptionMessage { get; set; }

    public Guid CorrelationId { get; set; }
}
