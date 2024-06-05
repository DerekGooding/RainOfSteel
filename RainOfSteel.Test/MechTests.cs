namespace RainOfSteel.Test;

[TestClass]
public class MechTests
{
    [TestMethod]
    public void Mech_ShouldInitializeWithGivenName()
    {
        // Arrange
        const string mechName = "Warrior";

        // Act
        Mech mech = new(mechName);

        // Assert
        Assert.AreEqual(mechName, mech.Name);
    }

    [TestMethod]
    public void Mech_ShouldAddComponent()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component component = new("Laser Cannon");

        // Act
        mech.AddComponent(component);

        // Assert
        Assert.IsTrue(mech.Components.Contains(component));
    }

    [TestMethod]
    public void Mech_ShouldNotExceedComponentLimit()
    {
        // Arrange
        Mech mech = new("Warrior");
        for (int i = 0; i < 5; i++)
        {
            mech.AddComponent(new Component($"Component{i}"));
        }
        Component extraComponent = new("Extra Component");

        // Act & Assert
        Assert.ThrowsException<ComponentLimitExceededException>(() => mech.AddComponent(extraComponent));
    }

    [TestMethod]
    public void Mech_ShouldRemoveComponent()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component component = new("Laser Cannon");
        mech.AddComponent(component);

        // Act
        mech.RemoveComponent(component);

        // Assert
        Assert.IsFalse(mech.Components.Contains(component));
    }

    [TestMethod]
    public void Mech_ShouldCalculateTotalWeight()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.AddComponent(new Component("Laser Cannon", 50, 10));
        mech.AddComponent(new Component("Shield Generator", 0, 15));

        // Act
        int totalWeight = mech.CalculateTotalWeight();

        // Assert
        Assert.AreEqual(25, totalWeight);
    }

    [TestMethod]
    public void Mech_ShouldCalculateTotalDamage()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.AddComponent(new Component("Laser Cannon", 50, 10));
        mech.AddComponent(new Component("Missile Launcher", 70, 20));

        // Act
        int totalDamage = mech.CalculateTotalDamage();

        // Assert
        Assert.AreEqual(120, totalDamage);
    }

    [TestMethod]
    public void Mech_ShouldInitializeWithDefaultHealth()
    {
        // Arrange
        Mech mech = new("Warrior");

        // Act
        int health = mech.Health;

        // Assert
        Assert.AreEqual(100, health); // Assuming default health is 100
    }

    [TestMethod]
    public void Mech_ShouldBeRepaired()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.Damage(30); // Assume this method damages the mech by 30 points

        // Act
        mech.Repair(20);

        // Assert
        Assert.AreEqual(90, mech.Health);
    }

    [TestMethod]
    public void Mech_ShouldTakeDamage()
    {
        // Arrange
        Mech mech = new("Warrior");

        // Act
        mech.Damage(40);

        // Assert
        Assert.AreEqual(60, mech.Health); // Assuming default health is 100
    }

    [TestMethod]
    public void Mech_ShouldReportStatus()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.Damage(40);

        // Act
        string status = mech.GetStatus();

        // Assert
        Assert.AreEqual("Warrior: Health = 60", status); // Assuming default health is 100
    }

    [TestMethod]
    public void Mech_ShouldAddAndUseWeaponComponent()
    {
        // Arrange
        Mech mech = new("Warrior");
        WeaponComponent weapon = new("Laser Cannon", 50, 10);

        // Act
        mech.AddComponent(weapon);

        // Assert
        Assert.IsTrue(mech.Components.Contains(weapon));
        Assert.AreEqual(50, weapon.Damage);
        Assert.AreEqual(10, weapon.Weight);
    }

    [TestMethod]
    public void Mech_ShouldAddAndUseShieldComponent()
    {
        // Arrange
        Mech mech = new("Warrior");
        ShieldComponent shield = new("Energy Shield", 0, 15, 30, 30);

        // Act
        mech.AddComponent(shield);

        // Assert
        Assert.IsTrue(mech.Components.Contains(shield));
        Assert.AreEqual(0, shield.Damage);
        Assert.AreEqual(15, shield.Weight);
        Assert.AreEqual(30, shield.Defense);
    }

    [TestMethod]
    public void Mech_ShouldNotAllowDuplicateComponents()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component component = new("Laser Cannon", 50, 10);
        mech.AddComponent(component);

        // Act & Assert
        Assert.ThrowsException<DuplicateComponentException>(() => mech.AddComponent(component));
    }

    [TestMethod]
    public void Mech_ShouldRemoveWeaponComponent()
    {
        // Arrange
        Mech mech = new("Warrior");
        WeaponComponent weapon = new("Laser Cannon", 50, 10);
        mech.AddComponent(weapon);

        // Act
        mech.RemoveComponent(weapon);

        // Assert
        Assert.IsFalse(mech.Components.Contains(weapon));
    }

    [TestMethod]
    public void Mech_ShouldHaveIncreasedDefenseWithShield()
    {
        // Arrange
        Mech mech = new("Warrior");
        ShieldComponent shield = new("Energy Shield", 0, 15, 30, 30);
        mech.AddComponent(shield);

        // Act
        int defense = mech.CalculateTotalDefense();

        // Assert
        Assert.AreEqual(30, defense);
    }

    [TestMethod]
    public void Mech_ShouldCalculateTotalEnergyConsumption()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.AddComponent(new Component("Laser Cannon", 50, 10, 20)); // Damage, Weight, Energy Consumption
        mech.AddComponent(new Component("Shield Generator", 0, 15, 10));

        // Act
        int totalEnergyConsumption = mech.CalculateTotalEnergyConsumption();

        // Assert
        Assert.AreEqual(30, totalEnergyConsumption);
    }

    [TestMethod]
    public void Mech_ShouldOverheatWithExcessiveEnergyConsumption()
    {
        // Arrange
        Mech mech = new("Warrior", maxEnergy: 50); // Assume mech has a max energy limit
        mech.AddComponent(new Component("Laser Cannon", 50, 10, 30));
        mech.AddComponent(new Component("Shield Generator", 0, 15, 25));

        // Act & Assert
        Assert.ThrowsException<OverheatException>(() => mech.CalculateTotalEnergyConsumption());
    }

    [TestMethod]
    public void Mech_ShouldApplyDamageReductionFromShield()
    {
        // Arrange
        Mech mech = new("Warrior");
        ShieldComponent shield = new("Energy Shield", 0, 15, 30, 20); // Damage, Weight, Energy, Defense
        mech.AddComponent(shield);
        int initialHealth = mech.Health;
        const int damage = 50;

        // Act
        mech.Damage(damage);
        int expectedHealth = initialHealth - (damage - shield.Defense);

        // Assert
        Assert.AreEqual(expectedHealth, mech.Health);
    }

    [TestMethod]
    public void Mech_ShouldHaveCorrectComponentTypes()
    {
        // Arrange
        Mech mech = new("Warrior");
        WeaponComponent weapon = new("Laser Cannon", 50, 10);
        ShieldComponent shield = new("Energy Shield", 0, 15, 30);
        mech.AddComponent(weapon);
        mech.AddComponent(shield);

        // Act
        var weapons = mech.GetComponentsOfType<WeaponComponent>();
        var shields = mech.GetComponentsOfType<ShieldComponent>();

        // Assert
        Assert.AreEqual(1, weapons.Count);
        Assert.AreEqual(1, shields.Count);
        Assert.AreEqual(weapon, weapons[0]);
        Assert.AreEqual(shield, shields[0]);
    }

    [TestMethod]
    public void Mech_ShouldRemoveAllComponents()
    {
        // Arrange
        Mech mech = new("Warrior");
        mech.AddComponent(new Component("Laser Cannon", 50, 10, 20));
        mech.AddComponent(new Component("Shield Generator", 0, 15, 10));

        // Act
        mech.RemoveAllComponents();

        // Assert
        Assert.AreEqual(0, mech.Components.Count);
    }

    [TestMethod]
    public void Mech_ShouldNotAddComponentWithoutDependencies()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component engine = new("Engine", 0, 20, 0);
        Component laserCannon = new("Laser Cannon", 50, 10, 20, [engine]);

        // Act & Assert
        Assert.ThrowsException<MissingDependencyException>(() => mech.AddComponent(laserCannon));
    }

    [TestMethod]
    public void Mech_ShouldAddComponentWithDependencies()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component engine = new("Engine", 0, 20, 0);
        Component laserCannon = new("Laser Cannon", 50, 10, 20, [engine]);

        // Act
        mech.AddComponent(engine);
        mech.AddComponent(laserCannon);

        // Assert
        Assert.IsTrue(mech.Components.Contains(engine));
        Assert.IsTrue(mech.Components.Contains(laserCannon));
    }

    [TestMethod]
    public void Mech_ShouldCalculateRepairCost()
    {
        // Arrange
        Mech mech = new("Warrior", 100);
        mech.Damage(30); // Assume this method damages the mech by 30 points

        // Act
        int repairCost = mech.CalculateRepairCost();

        // Assert
        Assert.AreEqual(30, repairCost); // Assuming 1 point of health = 1 unit of repair cost
    }

    [TestMethod]
    public void Mech_ShouldCalculateEnergyEfficiency()
    {
        // Arrange
        Mech mech = new("Warrior");
        Component engine = new("Engine", 0, 20, 0);
        Component laserCannon = new("Laser Cannon", 50, 10, 20);
        mech.AddComponent(engine);
        mech.AddComponent(laserCannon);

        // Act
        double energyEfficiency = mech.CalculateEnergyEfficiency();

        // Assert
        Assert.AreEqual(1.5, energyEfficiency); // Assuming energy efficiency is calculated as (total damage / total energy consumption)
    }

    [TestMethod]
    public void Mech_ShouldNotExceedLoadCapacity()
    {
        // Arrange
        Mech mech = new("Warrior", maxLoadCapacity: 50); // Assume mech has a max load capacity
        Component heavyComponent = new("Heavy Armor", 0, 60, 0); // Exceeds load capacity

        // Act & Assert
        Assert.ThrowsException<LoadCapacityExceededException>(() => mech.AddComponent(heavyComponent));
    }

    [TestMethod]
    public void Mech_ShouldCalculateSpeed()
    {
        // Arrange
        Mech mech = new("Warrior", baseSpeed: 100); // Assume mech has a base speed
        Component engine = new("Engine", 0, 20, 0, speedBoost: 20);
        mech.AddComponent(engine);

        // Act
        int speed = mech.CalculateSpeed();

        // Assert
        Assert.AreEqual(120, speed); // Base speed + speed boost from engine
    }
}
