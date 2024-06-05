namespace RainOfSteel.Test;

[TestClass]
public class PerformanceTests
{
    [TestMethod]
    public void Mech_ShouldAnalyzePerformance()
    {
        // Arrange
        Mech mech = new("Warrior");
        WeaponComponent weapon = new("Laser Cannon", 50, 10);
        mech.AddComponent(weapon);

        // Act
        PerformanceReport report = mech.AnalyzePerformance();

        // Assert
        Assert.AreEqual(50, report.TotalDamageOutput);
        Assert.AreEqual(10, report.TotalWeight);
    }
}