using System.Threading.Tasks;

namespace CounterService.Api.ServiceClients
{
    interface ICounterServiceClient
    {
        Task IncrementAsync(string counter);
        Task DecrementAsync(string counter);
        Task DeleteAsync(string counter);
        Task<int?> GetAsync(string counter);
    }
}
