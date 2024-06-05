namespace RainOfSteel.Exceptions;

internal class LoadCapacityExceededException : Exception
{
    public LoadCapacityExceededException()
    {
    }

    public LoadCapacityExceededException(string? message) : base(message)
    {
    }

    public LoadCapacityExceededException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}