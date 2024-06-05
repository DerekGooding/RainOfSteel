namespace RainOfSteel.Test;

[TestClass]
public class BattleHistoryTests
{
    [TestMethod]
    public void Mech_ShouldTrackBattleHistory()
    {
        // Arrange
        Mech mech = new("Warrior");
        BattleHistory history = new();
        Battle battle1 = new(mech, new Mech("Enemy1"));
        Battle battle2 = new(mech, new Mech("Enemy2"));

        // Act
        history.RecordBattle(battle1);
        history.RecordBattle(battle2);
        List<Battle> battles = history.GetBattles(mech);

        // Assert
        Assert.AreEqual(2, battles.Count);
        Assert.IsTrue(battles.Contains(battle1));
        Assert.IsTrue(battles.Contains(battle2));
    }
}