namespace FactoryMethodPattern5.Factories;

internal interface IExporter
{
    public Task Run(CancellationToken cancellationToken);
}

internal class CompanyExporter : IExporter
{
    public Task Run(CancellationToken cancellationToken)
    {
        System.Console.WriteLine("Company Exporter runs...");
        return Task.CompletedTask;
    }
}

internal class UserExporter : IExporter
{
    public Task Run(CancellationToken cancellationToken)
    {
        System.Console.WriteLine("User Exporter runs...");
        return Task.CompletedTask;
    }
}

internal class RegionExporter : IExporter
{
    public Task Run(CancellationToken cancellationToken)
    {
        System.Console.WriteLine("Region Exporter runs...");
        return Task.CompletedTask;
    }
}
