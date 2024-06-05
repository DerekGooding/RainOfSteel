namespace RainOfSteel.Exceptions;

internal class ComponentFailureException : Exception
{
    public ComponentFailureException()
    {
    }

    public ComponentFailureException(string? message) : base(message)
    {
    }

    public ComponentFailureException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}