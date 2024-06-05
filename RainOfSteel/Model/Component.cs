namespace RainOfSteel.Model;

internal class Component(string name, int damage = 0, int weight = 0, int energyConsumption = 0, List<Component>? dependencies = null, int durability = 100, int speedBoost = 0)
{
    public string Name { get; set; } = name;
    public int Damage { get; set; } = damage;
    public int Weight { get; set; } = weight;
    public int Durability { get; set; } = durability;
    public int SpeedBoost { get; set; } = speedBoost;
    public List<Component>? Dependencies { get; } = dependencies;

    public int EnergyConsumption { get; set; } = energyConsumption;


    internal string GetStatus() => $"{Name}: Damage = {Damage}, Weight = {Weight}, Energy Consumption = {EnergyConsumption}";

    internal void Upgrade(int newDamage, int newWeight, int newEnergyConsumption)
    {
        Damage = newDamage;
        Weight = newWeight;
        EnergyConsumption = newEnergyConsumption;
    }

    internal void Use() => Durability -= 10;

    internal int GetWearAndTear() => 100 - Durability;
}
