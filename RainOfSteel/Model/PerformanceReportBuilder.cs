namespace RainOfSteel.Model;

internal class PerformanceReportBuilder()
{
    private readonly PerformanceReport _performanceReport = new();

    public PerformanceReportBuilder GetDamageOutput(Mech mech)
    {
        _performanceReport.TotalDamageOutput = mech.CalculateTotalDamage();
        return this;
    }

    public PerformanceReportBuilder GetWeight(Mech mech)
    {
        _performanceReport.TotalWeight = mech.CalculateTotalWeight();
        return this;
    }

    public PerformanceReport Build() => _performanceReport;
}
