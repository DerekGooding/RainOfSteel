namespace RainOfSteel.Test;

[TestClass]
public class BattlePredictionTests
{
    [TestMethod]
    public void Mech_ShouldPredictBattleOutcome()
    {
        // Arrange
        Mech mech1 = new("Warrior1");
        Mech mech2 = new("Warrior2");

        WeaponComponent weapon1 = new("Laser Cannon", 50, 10);
        WeaponComponent weapon2 = new("Missile Launcher", 70, 20);
        mech1.AddComponent(weapon1);
        mech2.AddComponent(weapon2);

        BattlePrediction prediction = new(mech1, mech2);

        // Act
        string outcome = prediction.Predict();

        // Assert
        Assert.AreEqual("Warrior2 is likely to win", outcome); // Assuming mech2 wins due to higher weapon damage
    }
}