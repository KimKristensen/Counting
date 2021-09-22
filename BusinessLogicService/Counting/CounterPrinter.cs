using CounterService.Api.ServiceClients;
using System;
using System.Timers;

namespace BusinessLogicService.Counting
{
    public class CounterPrinter
    {
        private Timer printTimer;
        private readonly CounterServiceClient counterServiceClient;

        public CounterPrinter(CounterServiceClient counterServiceClient)
        {
            this.counterServiceClient = counterServiceClient;

            printTimer = new Timer();
            printTimer.Elapsed += (o, s) => PrintCounters();
            printTimer.Interval = 1000;
        }

        public void Start()
        {
            printTimer.Start();
        }

        public void Stop()
        {
            printTimer.Stop();
        }

        private async void PrintCounters()
        {
            try
            {
                var aaCounter = await counterServiceClient.GetAsync("AA");
                var bbCounter = await counterServiceClient.GetAsync("BB");
                var ccCounter = await counterServiceClient.GetAsync("CC");
                var clients = await counterServiceClient.GetAsync("clients_connected");

                Console.WriteLine($"AA: {aaCounter}, BB: {bbCounter}, CC: {ccCounter}, Clients: {clients}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
