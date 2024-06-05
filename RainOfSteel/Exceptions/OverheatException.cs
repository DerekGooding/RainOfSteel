namespace RainOfSteel.Exceptions;

internal class OverheatException : Exception
{
    public OverheatException()
    {
    }

    public OverheatException(string? message) : base(message)
    {
    }

    public OverheatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}