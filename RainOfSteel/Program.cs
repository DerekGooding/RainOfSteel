namespace RainOfSteel;
public static class Program
{
    public static bool IsExit;
    private static void Main()
    {
        while (!IsExit)
        {
            HandlePrint();

            HandleInput(Console.ReadLine() ?? string.Empty);
        }
    }

    private static void HandlePrint()
    {
        Console.Clear();
        Console.WriteLine("Over here\tOver There");
    }

    private static void HandleInput(string line)
    {
        switch (line.ToLower())
        {
            case "x":
                IsExit = true;
                break;
        }
    }
}