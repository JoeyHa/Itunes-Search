using ItunesSearchData.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItunesSearchData
{
    public class SearchService : ISearchService
    {
        private const string BaseUrl = "https://itunes.apple.com/search?term=";
        private const string limit = "&limit=25";
        private const string BaseUrlLookup = "https://itunes.apple.com/lookup?id=";
        private readonly HttpClient _client;

        public SearchService(HttpClient client)
        {
            _client = client;
        }

        public Task<List<Search>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SearchJson> GetSearchAsync(string query)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}{query}{limit}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var searchItem = JsonConvert.DeserializeObject<SearchJson>(content);
            return searchItem;
        }
        public async Task<SearchLookUp> GetSearchLookUpAsync(int id)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrlLookup}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var lookUpItem = JsonConvert.DeserializeObject<SearchLookUp>(content);
            return lookUpItem;
        }


    }
}
