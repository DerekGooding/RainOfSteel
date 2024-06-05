namespace RainOfSteel.Test;

[TestClass]
public class AdvancedRepairTests
{
    [TestMethod]
    public void Mech_ShouldApplyAdvancedRepairTechniques()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component component = new("Laser Cannon", 50, 10, 20, durability: 50); // Partially worn component
        mech.AddComponent(component);

        AdvancedRepairTechnique technique = new("Nanobots");

        // Act
        mech.ApplyRepairTechnique(component, technique);

        // Assert
        Assert.AreEqual(100, component.Durability); // Assuming nanobots fully restore durability
    }
}