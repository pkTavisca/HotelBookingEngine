using System;
using HotelBookingServer.Constants;
using HotelBookingServer.Contracts;
using HotelBookingServer.Generators;
using HotelBookingServer.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Http;
using HotelBookingServer.Implementations;

namespace HotelBookingServer.Services
{
    public class SearchService
    {
        private ISearchAutoSuggestCache _searchAutoSuggestResultsCache = SearchAutosuggestCacheGenerator.Generate(CacheType.InMemory);
        private AppSettings _appSettings;

        public SearchService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string OnNewSearch(SearchObject searchObject)
        {
            string sessionId = Guid.NewGuid().ToString();
            SearchDataCache.AddToCache(sessionId, searchObject);
            return sessionId;
        }

        private void GetResults(string searchTerm)
        {
            string autosuggestApiUrl = _appSettings.SearchAutosuggestApiBaseUrl + searchTerm;
            string autosuggestResult = MakeApiCall(autosuggestApiUrl);
            _searchAutoSuggestResultsCache.AddToCache(searchTerm, autosuggestResult);
        }

        private string MakeApiCall(string autosuggestApiUrl)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(autosuggestApiUrl).GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return content;
        }

        public SearchObject GetSearchObject(string searchId)
        {
            return SearchDataCache.GetFromCache(searchId);
        }

        public string GetAutoSuggestResults(string searchTerm)
        {
            if (_searchAutoSuggestResultsCache.Contains(searchTerm))
                return _searchAutoSuggestResultsCache.GetFromCache(searchTerm);
            GetResults(searchTerm);
            return _searchAutoSuggestResultsCache.GetFromCache(searchTerm);
        }
    }
}
