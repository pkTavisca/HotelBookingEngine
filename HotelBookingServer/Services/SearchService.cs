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
            Task.Factory.StartNew(() => AddResultsToCache(searchObject, searchGuid));
            return searchGuid;
        }

        private void AddResultsToCache(SearchObject searchObject, string searchGuid)
        {
            string autosuggestApiUrl = _appSettings.SearchAutosuggestApiBaseUrl + searchObject.SearchTerm;
            string autosuggestResult = MakeApiCall(autosuggestApiUrl);
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

        public object GetAutoSuggestResults(string searchId)
        {
            return null;
        }
    }
}
