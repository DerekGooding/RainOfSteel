namespace RainOfSteel.Test;

[TestClass]
public class CustomizationTests
{
    [TestMethod]
    public void Mech_ShouldAllowCustomization()
    {
        // Arrange
        Mech mech = new("Warrior");
        CustomizationOption paintJob = new CustomizationOption("Camo Paint", "Green and Brown");

        // Act
        mech.ApplyCustomization(paintJob);

        // Assert
        Assert.AreEqual("Camo Paint: Green and Brown", mech.Customizations[0].ToString());
    }
}