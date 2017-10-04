using HotelBookingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Contracts
{
    public interface ISearchCache
    {
        string AddToCache(SearchObject searchObject);
        SearchObject GetFromCache(string searchId);
    }
}
