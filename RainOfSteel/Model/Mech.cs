using RainOfSteel.Exceptions;
using RainOfSteel.Model.Environmental;

namespace RainOfSteel.Model;

internal class Mech(string name, int health = 100, int maxEnergy = 50, int maxLoadCapacity = 50, int baseSpeed = 100)
{
    public string Name { get; set; } = name;
    public int Health { get; set; } = health;
    public int MaxHealth { get; set; } = health;
    public int Energy { get; set; } = maxEnergy;
    public int MaxEnergy { get; set; } = maxEnergy;
    public int MaxLoadCapacity { get; set; } = maxLoadCapacity;
    public int BaseSpeed { get; set; } = baseSpeed;

    public BattleTactic? BattleTactic { get; set; } = null;

    public List<Component> Components = [];

    public List<CustomizationOption> Customizations = [];

    internal List<T?> GetComponentsOfType<T>() where T : Component => Components.Where(x => x is T).Select(x => x as T).ToList();

    internal void AddComponent(Component component)
    {
        if (component.Weight > MaxLoadCapacity)
            throw new LoadCapacityExceededException();
        if (Components.Count >= 5)
            throw new ComponentLimitExceededException();
        if(Components.Contains(component))
            throw new DuplicateComponentException();
        foreach(var dependancy in component.Dependencies ?? [])
            if(!Components.Contains(dependancy))
                throw new MissingDependencyException();
        Components.Add(component);
    }

    internal void RemoveComponent(Component component) => Components.Remove(component);

    internal int CalculateTotalWeight() => Components.Sum(x => x.Weight);

    internal int CalculateTotalDamage() => Components.Sum(x => x.Damage);

    internal int CalculateTotalDefense() => Components.Sum(x => x is ShieldComponent shield ? shield.Defense : 0);

    internal int CalculateTotalEnergyConsumption()
    {
        var total = Components.Sum(x => x.EnergyConsumption);
        return total <= MaxEnergy ? total : throw new OverheatException();
    }

    internal int CalculateRepairCost() => MaxHealth - Health;

    internal int CalculateEnergyUsage() => Components.Sum(x => x.EnergyConsumption);

    internal double CalculateEnergyEfficiency() => CalculateTotalDamage() / CalculateEnergyUsage();

    internal int CalculateSpeed() => Components.Sum(x => x.SpeedBoost) + BaseSpeed;

    internal void Damage(int amount) => Health = Math.Max(Health - Math.Max(amount - CalculateTotalDefense(), 0), 0);

    internal void Repair(int amount) => Health = Math.Min(Health + amount, MaxHealth);

    internal string GetStatus() => $"{Name}: Health = {Health}";

    internal void RemoveAllComponents() => Components.Clear();

    internal void Attack(Mech mech)
    {
        mech.Damage(CalculateTotalDamage());
        mech.Energy -= CalculateEnergyUsage();
    }

    internal void ApplyTactic(BattleTactic? battleTactic) => BattleTactic = battleTactic;

    internal int GetTacticEffectiveness() => BattleTactic?.Effectiveness ?? 0;

    internal void ApplyRepairTechnique(Component component, AdvancedRepairTechnique repairTechnique)
    {

    }

    internal void RepairComponent(Component component) => component.Durability = 100;

    internal void CheckComponents()
    {
        if (Components.Any(x => x.Durability <= 0))
            throw new ComponentFailureException();
    }

    internal void ApplyCustomization(CustomizationOption customizationOption) => Customizations.Add(customizationOption);

    internal PerformanceReport AnalyzePerformance()
        => new PerformanceReportBuilder()
            .GetWeight(this)
            .GetDamageOutput(this)
            .Build();
}
