namespace RainOfSteel.Test;

[TestClass]
public class EnvironmentalTests
{
    [TestMethod]
    public void Mech_ShouldTakeEnvironmentalDamage()
    {
        // Arrange
        Mech mech = new("Warrior");
        EnvironmentalHazard fire = new("Fire", 20);

        // Act
        fire.ApplyTo(mech);

        // Assert
        Assert.AreEqual(80, mech.Health); // Assuming default health is 100 and fire deals 20 damage
    }

    [TestMethod]
    public void Mech_ShouldReceiveEnvironmentalBuff()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.Damage(20);
        EnvironmentalBuff energyField = new("Energy Field", 20);

        // Act
        energyField.ApplyTo(mech);

        // Assert
        Assert.AreEqual(100, mech.Health); // Assuming default health is 100 and energy field heals 20 health
    }
}