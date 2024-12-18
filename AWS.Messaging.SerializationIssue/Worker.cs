using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AWS.Messaging.SerializationIssue;

internal class Worker(
    ILogger<Worker> logger,
    IHostApplicationLifetime lifetime,
    IMessagePublisher messagePublisher
)
    : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var payload = new Payload
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                SomeValue = 42
            };
            await messagePublisher.PublishAsync(payload, cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occured");
        }
        finally
        {
            lifetime.StopApplication();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}