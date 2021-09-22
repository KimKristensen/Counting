using BusinessLogicService.Counting;
using CounterService.Api.ServiceClients;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicService
{
    public class Application : IHostedService
    {
        private const string serverUrl = "https://localhost:5001";

        private CounterServiceClient counterServiceClient;
        private CounterUpdater counterUpdater;
        private CounterPrinter counterPrinter;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            counterServiceClient = new CounterServiceClient(serverUrl);

            await counterServiceClient.IncrementAsync("clients_connected");

            counterPrinter = new CounterPrinter(counterServiceClient);
            counterPrinter.Start();

            counterUpdater = new CounterUpdater(counterServiceClient);
            counterUpdater.Start();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            counterPrinter.Stop();
            counterUpdater.Stop();

            await counterServiceClient.DecrementAsync("clients_connected");
        }
    }
}
