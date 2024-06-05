namespace RainOfSteel.Model.Environmental;

internal interface IEnvironmental
{
    public string Name { get; set; }

    public abstract void ApplyTo(Mech mech);
}
