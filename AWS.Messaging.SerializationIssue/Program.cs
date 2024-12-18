using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AWS.Messaging.SerializationIssue;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddAWSMessageBus(bus =>
        {
            bus.AddEventBridgePublisher<Payload>("{YourEventBusArn}", nameof(Payload));
        });

        builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        await host.RunAsync();
    }
}