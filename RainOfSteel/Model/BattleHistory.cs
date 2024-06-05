namespace RainOfSteel.Model;

internal class BattleHistory()
{
    public List<Battle> Battles { get; set; } = [];

    public void RecordBattle(Battle battle) => Battles.Add(battle);

    public List<Battle> GetBattles(Mech mech) => [.. Battles.Where(x => x.Mech == mech)];
}
