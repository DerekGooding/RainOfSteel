namespace RainOfSteel.Model;

internal class MaintenanceSchedule()
{
    public List<Mech> Mechs { get; set; } = [];

    public void AddMechForMaintenance(Mech mech) => Mechs.Add(mech);

    public bool IsMechScheduled(Mech mech) => Mechs.Any(x => x == mech && x.Health < x.MaxHealth);
}
