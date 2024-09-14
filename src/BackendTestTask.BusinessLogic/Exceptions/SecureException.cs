namespace BackendTestTask.BusinessLogic.Exceptions;

public class SecureException : Exception
{
    public SecureException(string? message) : base(message)
    {
    }

    public static void ThrowIfNull(object? argument, string? paramName = null)
    {
        if (argument is null)
        {
            throw new SecureException(paramName);
        }
    }

    public static void ThrowIfTrue(bool flag, string? paramName = null)
    {
        if (flag)
        {
            throw new SecureException(paramName);
        }
    }
}
