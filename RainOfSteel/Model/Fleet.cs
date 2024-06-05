namespace RainOfSteel.Model;

internal class Fleet()
{
    public List<Mech> Mechs { get; set; } = [];

    internal void AddMech(Mech mech) => Mechs.Add(mech);
}
