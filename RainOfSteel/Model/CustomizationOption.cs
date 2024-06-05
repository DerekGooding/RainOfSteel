namespace RainOfSteel.Model;

internal class CustomizationOption(string name, string description)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;

    public override string ToString() => $"{Name}: {Description}";
}
