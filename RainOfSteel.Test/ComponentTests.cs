namespace RainOfSteel.Test;

[TestClass]
public class ComponentTests
{
    [TestMethod]
    public void Component_ShouldInitializeWithGivenProperties()
    {
        // Arrange
        const string componentName = "Laser Cannon";
        const int damage = 50;
        const int weight = 10;

        // Act
        Component component = new(componentName, damage, weight);

        // Assert
        Assert.AreEqual(componentName, component.Name);
        Assert.AreEqual(damage, component.Damage);
        Assert.AreEqual(weight, component.Weight);
    }

    [TestMethod]
    public void Component_ShouldHaveStatus()
    {
        // Arrange
        Component component = new("Laser Cannon", 50, 10, 20);
        const string expectedStatus = "Laser Cannon: Damage = 50, Weight = 10, Energy Consumption = 20";

        // Act
        string status = component.GetStatus();

        // Assert
        Assert.AreEqual(expectedStatus, status);
    }

    [TestMethod]
    public void Component_ShouldBeUpgradable()
    {
        // Arrange
        Component component = new("Laser Cannon", 50, 10, 20);
        const int newDamage = 70;
        const int newWeight = 8;
        const int newEnergyConsumption = 25;

        // Act
        component.Upgrade(newDamage, newWeight, newEnergyConsumption);

        // Assert
        Assert.AreEqual(newDamage, component.Damage);
        Assert.AreEqual(newWeight, component.Weight);
        Assert.AreEqual(newEnergyConsumption, component.EnergyConsumption);
    }

    [TestMethod]
    public void Component_ShouldDecreaseDurabilityWithUse()
    {
        // Arrange
        Component component = new("Laser Cannon", 50, 10, 20, durability: 100);

        // Act
        component.Use();
        component.Use();

        // Assert
        Assert.AreEqual(80, component.Durability); // Assuming each use decreases durability by 10
    }

    [TestMethod]
    public void Component_ShouldTrackWearAndTear()
    {
        // Arrange
        Component component = new("Laser Cannon", 50, 10, 20, durability: 100);

        // Act
        component.Use(); // Assume each use decreases durability by 10
        int wearAndTear = component.GetWearAndTear();

        // Assert
        Assert.AreEqual(10, wearAndTear); // Initial durability 100 - 1 use (10) = 90; Wear and tear = 100 - 90
    }

    [TestMethod]
    public void Component_ShouldBeReplacedAfterFailure()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component component = new("Laser Cannon", 50, 10, 20, durability: 10); // Low durability for quick failure
        mech.AddComponent(component);

        // Act
        component.Use(); // Assume this method decreases durability
        component.Use(); // Assume this method decreases durability again

        // Assert
        Assert.ThrowsException<ComponentFailureException>(() => mech.CheckComponents()); // Assume this method checks component status
    }
}
