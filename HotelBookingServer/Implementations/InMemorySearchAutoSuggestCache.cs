using HotelBookingServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingServer.Models;

namespace HotelBookingServer.Implementations
{
    public class InMemorySearchAutoSuggestCache : ISearchAutoSuggestCache
    {
        private Dictionary<string, string> _cache = new Dictionary<string, string>();
        private Queue<string> _storedcache;
        private int _size;
        public InMemorySearchAutoSuggestCache(int size=1000)
        {
            _size = size;
            _cache = new Dictionary<string, string>(_size);
            _storedcache = new Queue<string>(_size);
        }

        public void AddToCache(string searchTerm, string searchAutosuggestObject)
        {

            if (_cache.Count == _size)
            {
                var oldestKey = _storedcache.Dequeue();
                _cache.Remove(oldestKey);
            }
            _cache[searchTerm] = searchAutosuggestObject;
            _storedcache.Enqueue(searchTerm);

        }

        public bool Contains(string searchTerm)
        {
            return _cache.ContainsKey(searchTerm);
        }

        public string GetFromCache(string searchTerm)
        {
            return _cache[searchTerm];
        }
    }
}
