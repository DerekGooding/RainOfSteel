namespace RainOfSteel.Model;

internal class ShieldComponent(string name, int damage = 0, int weight = 0, int energyUsage = 0, int defense = 0) : Component(name, damage, weight, energyUsage)
{
    public int Defense { get; set; } = defense;
}
