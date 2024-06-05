namespace RainOfSteel.Test;

[TestClass]
public class StrategyTests
{
    [TestMethod]
    public void Mechs_ShouldExecuteCoordinatedAttack()
    {
        // Arrange
        Mech mech1 = new("Warrior1");
        Mech mech2 = new("Warrior2");
        Mech enemy = new("Enemy");

        WeaponComponent weapon1 = new("Laser Cannon", 50, 10);
        WeaponComponent weapon2 = new("Missile Launcher", 70, 20);
        mech1.AddComponent(weapon1);
        mech2.AddComponent(weapon2);

        List<Mech> attackingMechs = [mech1, mech2];
        CoordinatedAttackStrategy strategy = new(attackingMechs, enemy);

        // Act
        strategy.Execute();

        // Assert
        Assert.AreEqual(0, enemy.Health); // Assuming coordinated attack depletes enemy health to 0
    }
}