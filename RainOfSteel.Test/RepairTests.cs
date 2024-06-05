namespace RainOfSteel.Test;

[TestClass]
public class RepairTests
{
    [TestMethod]
    public void Mech_ShouldRepairDamagedComponents()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component component = new("Laser Cannon", 50, 10, 20, durability: 100);
        mech.AddComponent(component);
        component.Use(); // Assume this decreases durability

        // Act
        mech.RepairComponent(component);
        int durability = component.Durability;

        // Assert
        Assert.AreEqual(100, durability); // Assuming repair restores full durability
    }
}