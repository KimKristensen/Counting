using CounterService.Api.ServiceClients;
using System;
using System.Timers;

namespace BusinessLogicService.Counting
{
    public class CounterUpdater
    {
        private Random random;
        private Timer updateTimer;
        private readonly CounterServiceClient counterServiceClient;

        public CounterUpdater(CounterServiceClient counterServiceClient)
        {
            this.counterServiceClient = counterServiceClient;

            random = new Random();

            updateTimer = new Timer();
            updateTimer.Elapsed += (o, s) => UpdateCounters();
            updateTimer.Interval = 200;
        }

        public void Start()
        {
            updateTimer.Start();
        }

        public void Stop()
        {
            updateTimer.Stop();
        }

        private async void UpdateCounters()
        {
            try
            {
                await counterServiceClient.IncrementAsync("AA");
                await counterServiceClient.IncrementAsync("BB");
                await counterServiceClient .IncrementAsync("BB");
                await counterServiceClient.DecrementAsync("CC");

                if (random.NextDouble() < 0.01)
                {
                    await counterServiceClient .DeleteAsync("CC");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
