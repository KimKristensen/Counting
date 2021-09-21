using Counters.Api.ServiceClients;
using System;
using System.Timers;

namespace CountingBusiness.Counting
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

        private void PrintCounters()
        {
            try
            {
                var aaCounter = counterServiceClient.GetAsync("AA").Result;
                var bbCounter = counterServiceClient.GetAsync("BB").Result;
                var ccCounter = counterServiceClient.GetAsync("CC").Result;
                Console.WriteLine($"AA: {aaCounter}, BB: {bbCounter}, CC: {ccCounter}");
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
