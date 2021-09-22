using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace BusinessLogicService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddHostedService<Application>())
                .RunConsoleAsync();
        }
    }
}
