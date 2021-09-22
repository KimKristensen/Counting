using CounterService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CounterService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountersController : ControllerBase
    {
        private readonly ILogger<CountersController> logger;
        private readonly ICounterStore counterStore;

        public CountersController(ICounterStore counterStore, ILogger<CountersController> logger)
        {
            this.logger = logger;
            this.counterStore = counterStore; ;
        }

        [HttpGet]
        public int? GetCounter(string counter)
        {
            return counterStore.GetCounter(counter);
        }

        [HttpPut]
        [Route("Increment")]
        public void IncrementCounter(string counter)
        {
            counterStore.Increment(counter);
        }

        [HttpPut]
        [Route("Decrement")]
        public void DecreaseCounter(string counter)
        {
            counterStore.Decrement(counter);
        }

        [HttpDelete]
        public void DeleteCounter(string counter)
        {
            counterStore.DeleteCounter(counter);
        }

    }
}
