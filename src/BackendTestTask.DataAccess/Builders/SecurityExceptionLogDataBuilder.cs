using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Builders;

public static class SecurityExceptionLogDataBuilder
{
    public static SecurityExceptionLogData Build(string exeptionMessage)
    {
        var data = new SecurityExceptionLogData()
        {
            Message = exeptionMessage,
        };

        return data;
    }
}
