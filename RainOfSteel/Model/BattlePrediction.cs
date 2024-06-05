using System.Runtime.ExceptionServices;

namespace RainOfSteel.Model;

internal class BattlePrediction(Mech mech, Mech enemy)
{
    public Mech Mech { get; set; } = mech;
    public Mech Enemy { get; set;} = enemy;

    public string Predict()
    {
        Mech first = new(Mech.Name)
        {
            Health = Mech.Health,
            MaxHealth = Mech.MaxHealth,
            MaxEnergy = Mech.MaxEnergy
        };
        foreach (var component in Mech.Components)
        {
            Component simulatedComponent = new(component.Name)
            {
                Durability = component.Durability,
                Weight = component.Weight,
                Damage = component.Damage
            };

            first.Components.Add(simulatedComponent);
        }
        Mech second = new(Enemy.Name)
        {
            Health = Enemy.Health,
            MaxHealth = Enemy.MaxHealth,
            MaxEnergy = Enemy.MaxEnergy
        };
        foreach (var component in Enemy.Components)
        {
            Component simulatedComponent = new(component.Name)
            {
                Durability = component.Durability,
                Weight = component.Weight,
                Damage = component.Damage
            };

            second.Components.Add(simulatedComponent);
        }

        while(Mech.Health > 0 && Enemy.Health > 0)
        {
            if (Mech.Health <= 0)
                return $"{Enemy.Name} is likely to win";
            if (Enemy.Health <= 0)
                return $"{Mech.Name} is likely to win";
            Mech.Attack(Enemy);
            Enemy.Attack(Mech);
        }
        return "They will destroy each other";
    }
}
