namespace RainOfSteel.Exceptions;

internal class DuplicateComponentException : Exception
{
    public DuplicateComponentException()
    {
    }

    public DuplicateComponentException(string? message) : base(message)
    {
    }

    public DuplicateComponentException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}