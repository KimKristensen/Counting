using Counters.Api.ServiceClients;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace CountingBusiness
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

        private void UpdateCounters()
        {
            try
            {
                counterServiceClient.IncrementAsync("AA").Wait();
                counterServiceClient.IncrementAsync("BB").Wait();
                counterServiceClient.IncrementAsync("BB").Wait();
                counterServiceClient.DecrementAsync("CC").Wait();

                if (random.NextDouble() < 0.01)
                {
                    counterServiceClient.DeleteAsync("CC").Wait();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
