namespace BackendTestTask.API.Contracts.Responses.ExceptionResponses;

public class ExceptionResponse
{
    public string Type { get; set; } = string.Empty;

    public Guid Id { get; set; }

    public ExceptionResponseData Data { get; set; } = new();
}
