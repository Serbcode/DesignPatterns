namespace FactoryMethodPattern5.Factories;

internal interface IExporterFactory
{
    public Task<IExporter> Create(CancellationToken cancellationToken);
}

internal class UserExporterFactory : IExporterFactory
{
    public Task<IExporter> Create(CancellationToken cancellationToken)
    {
        return Task.FromResult<IExporter>(new UserExporter());
    }
}

internal class CompanyExporterFactory : IExporterFactory
{
    public Task<IExporter> Create(CancellationToken cancellationToken)
    {
        return Task.FromResult<IExporter>(new CompanyExporter());
    }
}

internal class RegionExporterFactory : IExporterFactory
{
    public Task<IExporter> Create(CancellationToken cancellationToken)
    {
        return Task.FromResult<IExporter>(new RegionExporter());
    }
}
