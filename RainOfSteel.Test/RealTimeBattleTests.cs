namespace RainOfSteel.Test;

[TestClass]
public class RealTimeBattleTests
{
    [TestMethod]
    public void Mechs_ShouldSimulateRealTimeBattle()
    {
        // Arrange
        Mech mech1 = new("Warrior1");
        Mech mech2 = new("Warrior2");

        WeaponComponent weapon1 = new("Laser Cannon", 50, 10);
        WeaponComponent weapon2 = new("Missile Launcher", 70, 20);
        mech1.AddComponent(weapon1);
        mech2.AddComponent(weapon2);

        //RealTimeBattle battle = new RealTimeBattle(mech1, mech2, duration: 5000); // 5 seconds battle duration

        // Act
        //battle.Start();
        Thread.Sleep(6000); // Wait for battle to complete

        // Assert
        Assert.IsTrue(false);
        //Assert.IsTrue(battle.HasEnded);
        //Assert.IsNotNull(battle.Winner);
    }
}