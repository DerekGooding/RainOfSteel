namespace RainOfSteel.Test;

[TestClass]
public class EnergyManagementTests
{
    [TestMethod]
    public void Mech_ShouldDepleteEnergyDuringBattle()
    {
        // Arrange
        Mech mech = new("Warrior", maxEnergy: 100);
        WeaponComponent weapon = new("Laser Cannon", 50, 10, energyUsage: 20);
        mech.AddComponent(weapon);

        Battle battle = new(mech, new Mech("Enemy"));

        // Act
        battle.Simulate();
        int remainingEnergy = mech.Energy;

        // Assert
        Assert.AreEqual(80, remainingEnergy); // Assuming one round of attack uses 20 energy
    }
}