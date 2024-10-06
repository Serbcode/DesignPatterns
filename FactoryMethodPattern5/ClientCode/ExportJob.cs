using FactoryMethodPattern5.Factories;

namespace FactoryMethodPattern5.ClientCode;

internal class ExportJob : IJob
{
    private readonly IExporterFactory _exporterFactory;

    private readonly ILogger<ExportJob> _logger;

    public ExportJob(IExporterFactory exporterFactory, ILogger<ExportJob> logger)
    {
        _exporterFactory = exporterFactory;
        _logger = logger;
    }

    /// <summary>
    /// The main idea of the pattern is here
    /// </summary>
    public async Task Run(CancellationToken cancellationToken)
    {
        IExporter exporter = await _exporterFactory.Create(cancellationToken);

        await exporter.Run(cancellationToken);

        _logger.LogInformation("Exported done.");
    }
}
