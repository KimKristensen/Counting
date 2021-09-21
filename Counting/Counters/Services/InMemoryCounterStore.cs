﻿using System;
using System.Collections.Concurrent;

namespace Counters.Services
{
    class InMemoryCounterStore : ICounterStore
    {
        private readonly ConcurrentDictionary<string, int> counters;

        public InMemoryCounterStore()
        {
            counters = new ConcurrentDictionary<string, int>();
        }

        public int GetCounter(string counter)
        {
            if(counters.TryGetValue(counter, out var c))
            {
                return c;
            }
            return 0;
        }

        public void Increment(string counter)
        {
            counters.AddOrUpdate(counter, 1, (key, oldValue) => oldValue + 1);
        }

        public void Decrement(string counter)
        {
            counters.AddOrUpdate(counter, -1, (key, oldValue) => oldValue - 1);
        }

    }
}
