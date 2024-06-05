namespace RainOfSteel.Model.Environmental;

internal class EnvironmentalBuff(string name, int amount) : IEnvironmental
{
    public string Name { get; set; } = name;
    public int Amount { get; set; } = amount;

    public void ApplyTo(Mech mech) => mech.Repair(Amount);
}
