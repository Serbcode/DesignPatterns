using FactoryMethodPattern5.ClientCode;
using FactoryMethodPattern5.Factories;

namespace FactoryMethodPattern5;


public class Program
{
    public static async Task Main(string[] args)
    {
        var factory = new UserExporterFactory();
        var logger = new ConsoleLogger<ExportJob>();

        IJob job = new ExportJob(factory, logger);
        await job.Run(CancellationToken.None);
    }
}
