using System.Threading.Tasks;

namespace Counters.Api.ServiceClients
{
    interface ICounterServiceClient
    {
        Task IncrementAsync(string counter);
        Task DecrementAsync(string counter);
        Task DeleteAsync(string counter);
        Task<int?> GetAsync(string counter);
    }
}
