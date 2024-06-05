namespace RainOfSteel.Model.Strategies;

internal class CoordinatedAttackStrategy(List<Mech> mechs, Mech target) : IStrategy
{
    public List<Mech> Mechs { get; } = mechs;
    public Mech Target { get; } = target;

    public void Execute()
    {
        foreach(var mech in Mechs)
            mech.Attack(Target);
    }
}
