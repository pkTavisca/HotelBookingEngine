using HotelBookingServer.Contracts;
using System;
using System.Collections.Generic;
using HotelBookingServer.Models;

namespace HotelBookingServer.Implementations
{
    public class InMemorySearchCache : ISearchCache
    {
        private Dictionary<string, SearchObject> _searches = new Dictionary<string, SearchObject>();
        private Queue<string> _keys;
        private int _capacity;

        public InMemorySearchCache(int capacity = 1000)
        {
            _capacity = capacity;
            _keys = new Queue<string>(_capacity);
            _searches = new Dictionary<string, SearchObject>(_capacity);
        }

        public string AddToCache(SearchObject searchObject)
        {
            if (_searches.Count == _capacity)
            {
                var oldestKey = _keys.Dequeue();
                _searches.Remove(oldestKey);
            }

            string guid = Guid.NewGuid().ToString();
            _searches.Add(guid, searchObject);
            _keys.Enqueue(guid);
            return guid;
        }

        public bool IsPresent(string id)
        {
            return _searches.ContainsKey(id);
        }

        public SearchObject GetFromCache(string searchId)
        {
            return _searches[searchId];
        }

    }
}
