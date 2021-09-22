using Counters.Api.ServiceClients;
using CountingBusiness.Counting;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace CountingBusiness
{
    public class Application : IHostedService
    {
        private const string serverUrl = "https://localhost:5001";

        private CounterUpdater counterUpdater;
        private CounterPrinter counterPrinter;

        public Task StartAsync(CancellationToken cancellationToken)
        {

            counterUpdater = new CounterUpdater(new CounterServiceClient(serverUrl));
            counterUpdater.Start();

            counterPrinter = new CounterPrinter(new CounterServiceClient(serverUrl));
            counterPrinter.Start();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            counterPrinter.Stop();
            counterUpdater.Stop();

            return Task.CompletedTask;
        }
    }
}
