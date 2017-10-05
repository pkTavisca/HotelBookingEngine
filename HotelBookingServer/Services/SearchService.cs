using System;
using HotelBookingServer.Constants;
using HotelBookingServer.Contracts;
using HotelBookingServer.Generators;
using HotelBookingServer.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace HotelBookingServer.Services
{
    public class SearchService
    {
        private ISearchCache _searchCache = SearchCacheGenerator.Generate(CacheType.InMemory);
        private ISearchAutoSuggestCache _searchAutoSuggestResultsCache = SearchAutosuggestCacheGenerator.Generate(CacheType.InMemory);
        private AppSettings _appSettings;

        public SearchService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string OnNewSearch(SearchObject searchObject)
        {
            string searchGuid = _searchCache.AddToCache(searchObject);
            return searchGuid;
        }

        private void AddResultsToCache(string searchTerm)
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
            return _searchCache.GetFromCache(searchId);
        }

        public string GetAutoSuggestResults(string searchTerm)
        {
            if (_searchAutoSuggestResultsCache.Contains(searchTerm))
                return _searchAutoSuggestResultsCache.GetFromCache(searchTerm);
            AddResultsToCache(searchTerm);
            return _searchAutoSuggestResultsCache.GetFromCache(searchTerm);
        }
    }
}
