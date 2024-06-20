namespace RainOfSteel.Extensions;

internal static class StringExtensions
{
    public static int ValidateInt(this string? str) => int.TryParse(str, out var result) ? result : 0;
}
