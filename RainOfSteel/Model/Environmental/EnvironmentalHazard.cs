namespace RainOfSteel.Model.Environmental;

internal class EnvironmentalHazard(string name, int amount) : IEnvironmental
{
    public string Name { get; set; } = name;

    public int Amount { get; set; } = amount;

    public void ApplyTo(Mech mech) => mech.Damage(Amount);
}
