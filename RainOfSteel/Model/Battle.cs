namespace RainOfSteel.Model;

internal class Battle(Mech mech, Mech enemy)
{
    public Mech Mech { get; set; } = mech;
    public Mech Enemy { get; set;} = enemy;

    public Mech Simulate()
    {
        return Mech;
    }
}
