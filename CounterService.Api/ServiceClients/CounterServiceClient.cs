using RestSharp;
using System.Threading.Tasks;

namespace CounterService.Api.ServiceClients
{
    public class CounterServiceClient
    {
        private readonly RestClient restClient;

        public CounterServiceClient(string serverUrl)
        {
            restClient = new RestClient(serverUrl);
        }

        public async Task IncrementAsync(string counter)
        {
            var request = new RestRequest($"Counters/Increment?counter={counter}");
            await restClient.PutAsync<string>(request);
        }

        public async Task DecrementAsync(string counter)
        {
            var request = new RestRequest($"Counters/Decrement?counter={counter}");
            await restClient.PutAsync<string>(request);
        }

        public async Task DeleteAsync(string counter)
        {
            var request = new RestRequest($"Counters?counter={counter}");
            await restClient.DeleteAsync<string>(request);
        }

        public async Task<int?> GetAsync(string counter)
        {
            var request = new RestRequest($"Counters?counter={counter}");
            var result = await restClient.GetAsync<int?>(request);
            return result;
        }
    }
}
