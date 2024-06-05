namespace RainOfSteel.Test;

[TestClass]
public class OverheatTests
{
    [TestMethod]
    public void Mech_ShouldOverheatInBattle()
    {
        // Arrange
        Mech mech = new("Warrior", maxEnergy: 50);
        WeaponComponent weapon = new("Laser Cannon", 50, 10, energyUsage: 30);
        mech.AddComponent(weapon);

        Battle battle = new(mech, new Mech("Enemy"));

        // Act & Assert
        Assert.ThrowsException<OverheatException>(() => battle.Simulate());
    }
}