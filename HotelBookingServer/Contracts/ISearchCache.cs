using HotelBookingServer.Models;

namespace HotelBookingServer.Contracts
{
    public interface ISearchCache
    {
        string AddToCache(SearchObject searchObject);
        SearchObject GetFromCache(string searchId);
    }
}
