namespace RainOfSteel.Test;

[TestClass]
public class BattleTacticsTests
{
    [TestMethod]
    public void Mech_ShouldImplementBattleTactics()
    {
        // Arrange
        Mech mech = new("Warrior");
        BattleTactic flankingManeuver = new("Flanking Maneuver", effectiveness: 20);

        // Act
        mech.ApplyTactic(flankingManeuver);
        int effectiveness = mech.GetTacticEffectiveness();

        // Assert
        Assert.AreEqual(20, effectiveness);
    }
}