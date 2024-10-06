namespace FactoryMethodPattern5.ClientCode;

internal interface IJob
{
    public Task Run(CancellationToken cancellationToken);
}
