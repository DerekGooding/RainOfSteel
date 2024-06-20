using static System.Console;

namespace RainOfSteel.Library;

public static class Program
{
    private static bool _isExiting;
    private static void Main()
    {
        while (!_isExiting)
        {
            Paint();
            Inquire();
        }
    }

    private static void Paint()
    {
        Clear();
        WriteLine("Welcome to the Rain of Steel Complete Library\n");
        WriteLine("What would you like to review?");
    }

    private static void Inquire()
    {
        string? result;
        while (string.IsNullOrWhiteSpace(result = ReadLine()))
            WriteLine("That is not a valid inquiry");
        switch (result.ToLower())
        {
            case "x":
                _isExiting = true;
                break;
        }
    }
}
