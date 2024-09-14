using BackendTestTask.API.Contracts.Responses.ExceptionResponses;

namespace BackendTestTask.API.Builders;

public static class ExceptionResponseBuilder
{
    public static ExceptionResponse Build(
        string type,
        Guid id,
        string message)
    {
        return new()
        {
            Type = type,
            Id = id,
            Data = new()
            {
                Message = message,
            }
        };
    }
}
