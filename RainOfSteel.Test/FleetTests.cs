namespace RainOfSteel.Test;

[TestClass]
public class FleetTests
{
    [TestMethod]
    public void Fleet_ShouldManageMultipleMechs()
    {
        // Arrange
        Fleet fleet = new();
        Mech mech1 = new("Warrior1");
        Mech mech2 = new("Warrior2");

        // Act
        fleet.AddMech(mech1);
        fleet.AddMech(mech2);

        // Assert
        Assert.AreEqual(2, fleet.Mechs.Count);
        Assert.IsTrue(fleet.Mechs.Contains(mech1));
        Assert.IsTrue(fleet.Mechs.Contains(mech2));
    }

    [TestMethod]
    public void Fleet_ShouldRespectComponentLimitAcrossMechs()
    {
        // Arrange
        Fleet fleet = new();
        Mech mech1 = new("Warrior1");
        Mech mech2 = new("Warrior2");

        for (int i = 0; i < 5; i++)
        {
            mech1.AddComponent(new Component($"Component{i}", 0, 5, 0));
        }
        Component extraComponent = new("Extra Component", 0, 5, 0);

        // Act & Assert
        Assert.ThrowsException<ComponentLimitExceededException>(() => mech1.AddComponent(extraComponent));
        mech2.AddComponent(extraComponent);
    }
}