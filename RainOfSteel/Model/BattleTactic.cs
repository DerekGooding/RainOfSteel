namespace RainOfSteel.Model;

internal class BattleTactic(string name, int effectiveness)
{
    public string Name { get; set; } = name;
    public int Effectiveness { get; set; } = effectiveness;

    public List<Battle> Battles { get; set; } = [];

    public void RecordBattle(Battle battle) => Battles.Add(battle);

    public List<Battle> GetBattles(Mech mech) => [.. Battles.Where(x => x.Mech == mech)];
}
