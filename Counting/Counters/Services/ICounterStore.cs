namespace Counters.Services
{
    public interface ICounterStore
    {
        void Increment(string counter);
        void Decrement(string counter);
        int? GetCounter(string counter);
        void DeleteCounter(string counter);
    }
}
