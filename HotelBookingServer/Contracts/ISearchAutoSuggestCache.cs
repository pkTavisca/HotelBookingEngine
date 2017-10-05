using HotelBookingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Contracts
{
    public interface ISearchAutoSuggestCache
    {
        void AddToCache(string searchTerm, string searchAutosuggestObject);
        string GetFromCache(string searchTerm);
        bool Contains(string searchTerm);
    }
}
