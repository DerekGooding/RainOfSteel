namespace RainOfSteel.Test;

[TestClass]
public class MaintenanceTests
{
    [TestMethod]
    public void Mech_ShouldScheduleMaintenance()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.Damage(30); // Assume this method damages the mech by 30 points
        MaintenanceSchedule schedule = new();

        // Act
        schedule.AddMechForMaintenance(mech);
        bool isScheduled = schedule.IsMechScheduled(mech);

        // Assert
        Assert.IsTrue(isScheduled);
    }
}