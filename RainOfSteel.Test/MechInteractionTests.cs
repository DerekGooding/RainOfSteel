namespace RainOfSteel.Test;

[TestClass]
public class MechInteractionTests
{
    [TestMethod]
    public void Mech_ShouldAttackAnotherMech()
    {
        // Arrange
        Mech attacker = new("Attacker");
        Mech defender = new("Defender");
        WeaponComponent weapon = new("Laser Cannon", 50, 10);
        attacker.AddComponent(weapon);

        // Act
        attacker.Attack(defender);

        // Assert
        Assert.AreEqual(50, defender.Health); // Assuming default health is 100
    }

    [TestMethod]
    public void Mech_ShouldDefendAgainstAttack()
    {
        // Arrange
        Mech attacker = new("Attacker");
        Mech defender = new("Defender");
        WeaponComponent weapon = new("Laser Cannon", 50, 10);
        ShieldComponent shield = new("Energy Shield", 0, 15, 30, 30);
        attacker.AddComponent(weapon);
        defender.AddComponent(shield);

        // Act
        attacker.Attack(defender);

        // Assert
        Assert.AreEqual(80, defender.Health); // Assuming default health is 100 and 30 defense from shield
    }
}