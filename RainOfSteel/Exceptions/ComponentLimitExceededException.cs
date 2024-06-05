namespace RainOfSteel.Exceptions;

internal class ComponentLimitExceededException : Exception
{
    public ComponentLimitExceededException()
    {
    }

    public ComponentLimitExceededException(string? message) : base(message)
    {
    }

    public ComponentLimitExceededException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}