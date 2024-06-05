namespace RainOfSteel.Test;

[TestClass]
public class BattleTests
{
    [TestMethod]
    public void Mech_ShouldWinBattle()
    {
        // Arrange
        Mech mech1 = new("Warrior1");
        Mech mech2 = new("Warrior2");

        WeaponComponent weapon1 = new("Laser Cannon", 50, 10);
        WeaponComponent weapon2 = new("Missile Launcher", 70, 20);
        mech1.AddComponent(weapon1);
        mech2.AddComponent(weapon2);

        // Act
        Battle battle = new(mech1, mech2);
        Mech winner = battle.Simulate();

        // Assert
        Assert.AreEqual(mech2, winner); // Assuming mech2 wins due to higher weapon damage
    }
}